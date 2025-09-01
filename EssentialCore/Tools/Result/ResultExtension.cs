using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EssentialCore.Controllers;
using EssentialCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EssentialCore.Tools.Result
{
    public static class ResultExtension
    {
        //public static IResult JsonToResult(this string resultJsonValue)
        //{
        //    IResult result = Serializer.JsonSerializerManager.Deserialize<Result>(resultJsonValue);

        //    if(result.IsSucceeded)

        //        return 
        //}
        
        
        
        public static DataResult<T> ToDataResult<T>(this Result result, T entity) where T : IEntityBase
        {
            return new DataResult<T>(result.Id, result.Message, result.OriginalMessage, entity);
        }

        public static DataResult<T> ToDataResult<T>(this Result result) where T : IEntityBase
        {
            return result.ToDataResult<T>(default);
        }

        public static DataResult<List<T>> ToListDataResult<T>(this List<T> list) where T : IEntityBase
        {
            if (list == null)

                return new ErrorDataResult<List<T>>(-1, "The list is Empty!");

            return new SuccessfulDataResult<List<T>>(list);
        }

        /// <summary>
        /// Return  Result to the Client
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static IActionResult ToActionResult(this Result result)
        {
            if (!result.IsSucceeded)

                return new BadRequestObjectResult(result);

            return new OkObjectResult(result);
        }




        public static IActionResult ToActionResult(this Task<Result> resultTask)
        {
            if(resultTask == null || resultTask.Result == null)

                return new BadRequestObjectResult(new ErrorResult(-1,"Result is not Valid",string.Empty));

            return resultTask.Result.ToActionResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataResult"></param>
        /// <returns></returns>
        public static IActionResult ToActionResult<T>(this ControllerBase controller, DataResult<T> dataResult) where T : IEntityBase
        {
            if (!dataResult.IsSucceeded)

                return controller.BadRequest(dataResult);

            return  controller.Ok(dataResult); //OkObjectResult(new SuccessfulDataResult<T>(dataResult.Data));
        }

        public static IActionResult ToActionResult<T>(this Task<DataResult<T>> dataResult) where T : IEntityBase
        {
           if(dataResult == null || dataResult.Result == null)

                return new BadRequestObjectResult(new ErrorResult(-1,"The result is not Valid!",string.Empty));

            return dataResult.Result.ToActionResult();
        }


        /// <summary>
        /// Return Data Result to the Client
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataResult"></param>
        /// <returns></returns>
        public static IActionResult ToActionResult<T>(this ControllerBase controller, DataResult<List<T>> dataResult) where T : IEntityBase
        {
            if (!dataResult.IsSucceeded || dataResult.Data == null)

                return controller.BadRequest(dataResult);

            return controller.Ok(dataResult);
        }

        //public static IActionResult ToActionResult<T>(this Task<DataResult<List<T>>>? dataResult) where T : IEntityBase
        //{
        //    if (!dataResult.Result.IsSucceeded || dataResult.Result.Data == null)

        //        return new BadRequestObjectResult(dataResult);

        //    return new OkObjectResult(dataResult);
        //}


        public static IActionResult ToActionResult<T>(this DataResult<List<T>>? dataResult) where T : IEntityBase
        {
            if (!dataResult.IsSucceeded || dataResult.Data == null)

                return new BadRequestObjectResult(dataResult);

            return new OkObjectResult(dataResult);
        }

        public static IActionResult ToActionResult<T>(this DataResult<T> dataResult) where T : IEntityBase
        {
            if (!dataResult.IsSucceeded || dataResult.Data == null)

                return new BadRequestObjectResult(dataResult);

            return new OkObjectResult(dataResult);
        }

    }
}
