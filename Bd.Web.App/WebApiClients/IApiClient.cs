using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bd.Web.App.WebApiClient
{
    public interface IApiClient
    {
        Task<IEnumerable<T>> ListAsync<T>(string uri);
        Task<IEnumerable<T>> ListAsync<T>();
        //Task<Result> ResultantListAsync<T>(string uri);
        Task<T> GetAsync<T>(string uri);
        //Task<T> GetAsync<T>();
        //Task<Result<T>> ResultantGetAsync<T>(string uri);
        Task PutAsync<T>(string uri, T updatedItem);
        //Task PutAsync<T>(T updatedItem);
        //Task<Result> ResultantPutAsync<T>(string uri, T updatedItem);
        Task<T> PostAsync<T>(string uri, T newItem);
        //Task<T> PostAsync<T>(T newItem);
        //Task<Result<T>> ResultantPostAsync<T>(string uri, T newItem);
        //Task<TResult> PostWithResultAsync<TData, TResult>(string uri, TData newItem);
        //Task<Result<TResult>> ResultantPostWithResultAsync<TData, TResult>(string uri, TData newItem);
        Task<bool> DeleteAsync(string uri);
    }
}
