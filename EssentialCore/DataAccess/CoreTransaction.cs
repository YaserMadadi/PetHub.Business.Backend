using EssentialCore.Tools.Logging;
using EssentialCore.Tools.Result;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.DataAccess
{
    public class CoreTransaction
    {

        public CoreTransaction()
        {
            try
            {
                this.Connection = ConnectionManager.GetNewConnectionString();

                this.Connection.Open();

                this.transaction = this.Connection.BeginTransaction();
            }
            catch
            {

            }
        }

        //        public static ConnectionManager ConnectionManager { get; set; }

        private SqlTransaction transaction { get; set; }

        private SqlConnection Connection { get; set; }

        public SqlCommand CreateCommand(string commandName, params SqlParameter[] parameters)
        {
            var command = this.Connection.CreateCommand();

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.CommandText = commandName;

            command.Parameters.AddRange(parameters);

            command.Transaction = this.transaction;

            return command;
        }

        public async Task<Result> ExecuteResult(SqlCommand command)
        {
            SqlDataReader reader = null;

            Result result = null;

            try
            {
                if (command.Connection.State != System.Data.ConnectionState.Open)
                {
                    command.Connection.Open();
                }


                reader = await command.ExecuteReaderAsync();

                await reader.ReadAsync();

                if (reader.GetInt32(0) <= 0)
                {
                    result = new ErrorResult()
                    {
                        Id = reader.GetInt32(0),
                        Message = reader.GetString(1),
                        OriginalMessage = reader.GetString(2)
                    };

                    this.RollBack();
                }

                result = new SuccessfulResult()
                {
                    Id = reader.GetInt32(0),
                    Message = reader.GetString(1),
                    OriginalMessage = reader.GetString(2)
                };

                this.Commit();

                return result;
            }
            catch (SqlException ex)
            {
                this.RollBack();

                await LogManager.Save(ex, command);

                return new ErrorResult(ex.ErrorCode, string.Empty, ex.Message);
            }
            catch (Exception ex)
            {
                this.RollBack();

                await LogManager.Save(ex, command);

                return new ErrorResult(-1, string.Empty, ex.Message);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                {
                    reader.Close();

                    await reader.DisposeAsync();
                }

                command.Dispose();
            }
        }

        public bool Commit()
        {
            try
            {
                if (this.transaction != null)
                {
                    this.transaction.Commit();

                    this.transaction.Dispose();

                    if (this.Connection.State == System.Data.ConnectionState.Open)
                    {
                        this.Connection.Close();

                        this.Connection.Dispose();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                //TODO: LogError
                return false;
            }
        }

        private void RollBack()
        {
            try
            {
                if (this.transaction != null)
                {
                    this.transaction.Rollback();

                    this.transaction.Dispose();

                    if (this.Connection.State == System.Data.ConnectionState.Open)
                    {
                        this.Connection.Close();

                        this.Connection.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: LogError
            }
        }
    }
}
