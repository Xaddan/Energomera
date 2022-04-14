using System.Collections.Generic;
using System.Linq;

namespace Application.Common.Models
{
    public class Result
    {
        public static Result Success => new Result();

        public static Result Fail(string error) => new(new Error(error));

        public static Result Fail(Error error) => new(error);

        public static Result Fail(ICollection<Error> errors) => new(errors);

        protected Result()
        {
        }

        protected Result(Result result)
        {
            Errors = result.Errors;
            SuccessMessage = result.SuccessMessage;
        }

        public Result(Error error)
        {
            Errors = new List<Error> { error };
        }

        public Result(ICollection<Error> errors)
        {
            Errors = errors;
        }
        
        public void AddError(string error)
        {
            if (Errors.All(el => el.Value != error))
            {
                Errors.Add(new Error(error));
            }
        }

        public void AddError(string key, string error)
        {
            if (Errors.All(el => el.Key != key && el.Value != error))
            {
                Errors.Add(new Error(key, error));
            }
        }
        
        public ICollection<Error> Errors { get; } = new List<Error>();

        public string SuccessMessage { get; set; } = string.Empty;

        public virtual bool IsSuccess => !Errors.Any();
    }
}
