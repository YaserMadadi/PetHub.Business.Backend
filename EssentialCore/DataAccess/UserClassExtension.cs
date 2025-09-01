using EssentialCore.Entities;
using EssentialCore.Tools.Logging;
using EssentialCore.Tools.Result;
using EssentialCore.Tools.Serializer;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.DataAccess
{
    public static class UserClassExtension
    {
        public async static Task<IResult> ExecuteResult(this SqlCommand command)
        {
            SqlDataReader reader = null;

            try
            {
                if (command.Connection.State != System.Data.ConnectionState.Open)

                    command.Connection.Open();

                reader = await command.ExecuteReaderAsync();

                int id = 0;

                string message = string.Empty,
                        originalMessage = string.Empty;

                while (reader.Read())
                {
                    id = reader.GetInt32(0);

                    message = reader.GetString(1);

                    originalMessage = reader.GetString(2) ?? string.Empty;
                }

                if (id <= 0)

                    return new ErrorResult(id, message, originalMessage);

                return new SuccessfulResult(id, message);
            }
            catch (SqlException ex)
            {
                await LogManager.Save(ex, command);

                return new ErrorResult(ex.Number, ex.Message, ex.Message);
            }
            catch (Exception ex)
            {
                await LogManager.Save(ex, command);

                return new ErrorResult(-1, ex.Message, ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();

                    await reader.DisposeAsync();
                }

                if (command.Connection.State == System.Data.ConnectionState.Open)

                    command.Connection.Close();

                command.Dispose();
            }
        }


        public async static Task<DataResult<T>> ExecuteDataResult<T>(this SqlCommand command, JsonType jsonType)
        {
            var dataResult = await ExecuteDataResult(command);

            if (!dataResult.IsSucceeded)

                return new ErrorDataResult<T>(default);

            return new SuccessfulDataResult<T>(dataResult.Data.Deserialize<T>(jsonType));
        }





        public async static Task<DataResult<string>> ExecuteDataResult(this SqlCommand command)
        {
            SqlDataReader reader = null;

            StringBuilder builder = new StringBuilder();

            try
            {
                if (command.Connection.State != System.Data.ConnectionState.Open)

                    command.Connection.Open();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    builder.Append(reader.GetString(0));
                }

                if (builder.Length <= 0)

                    return new ErrorDataResult<string>(-1, "There is no data in Database", string.Empty);

                return new SuccessfulDataResult<string>(builder.ToString());
            }
            catch (SqlException ex)
            {
                await LogManager.Save(ex, command);

                return new ErrorDataResult<string>(ex.Number, "Sql Exception ( Related to DataBase )", ex.Message, string.Empty);
            }
            catch (Exception ex)
            {
                await LogManager.Save(ex, command);

                return new ErrorDataResult<string>(-1, "Exception", ex.Message, string.Empty);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();

                    reader.DisposeAsync();
                }


                if (command.Connection.State == System.Data.ConnectionState.Open)

                    command.Connection.Close();

                command.Dispose();
            }
        }
    }
}
