using System;
using System.Collections.Generic;

namespace Application.Common.Models
{
    public class Result<T> : Result
    {
        public new static Result<T> Success(T resultModel) => new(resultModel);

        public new static Result<T> Success(T resultModel, string successMessage) => new(resultModel, successMessage);

        public new static Result<T> Fail(string error) => new(new Error(error));

        public new static Result<T> Fail(Error error) => new(error);

        public new static Result<T> Fail(ICollection<Error> errors) => new(errors);

        private Result(T entity)
        {
            Entity = entity;
        }

        private Result(T entity, string successMessage)
        {
            Entity = entity;
            SuccessMessage = successMessage;
        }

        public Result(Result result) : base(result)
        {
            Entity = Activator.CreateInstance<T>();
        }

        public Result(Error error) : base(error)
        {
            Entity = Activator.CreateInstance<T>();
        }

        public Result(ICollection<Error> errors) : base(errors)
        {
            Entity = Activator.CreateInstance<T>();
        }
        
        public T Entity { get; }

        public override bool IsSuccess => base.IsSuccess && !Entity!.Equals(default(T));
    }
}
