using MediaLibrary.CrossCutting.Models;
using MediaLibrary.Data.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Http;

namespace MediaLibrary.API.Controllers
{
	public class MediasController : ApiController
    {
           
        private static MediaRepository repository = new MediaRepository();

        // GET: api/Medias
        public async Task<IEnumerable<Media>> GetAsync()
        {
            List<Media> medias;

            try
			{
                medias = await repository.GetAllAsync();
			}

            catch (SqlException ex)
            {
                throw ex;
			}

			catch (Exception ex)
			{
				throw ex;
			}

            return medias;
        }

        // GET: api/Medias/5
        public async Task<Media> GetAsync(int id)
        {
            Media media;

            try
            {
                media = await repository.GetByIdAsync(id);
            }

            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return media;
        }

        // POST: api/Medias
        public async Task<int> PostAsync([FromBody] string task)
        {
            int records;

            try
            {
               records = await repository.CreateAsync(JsonConvert.DeserializeObject<Media>(task));
            }

            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return records;
        }

        // PUT: api/Medias/5
        public async Task<int> PutAsync([FromBody] string task)
        {
            int records;

            try
            {
                records = await repository.UpdateAsync(JsonConvert.DeserializeObject<Media>(task));
            }

            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return records;
        }

        // DELETE: api/Medias/5
        public async Task<int> DeleteAsync(int id)
        {
            int records;

            try
            {
                records = await repository.DeleteAsync(id);
            }

            catch (SqlException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return records;
        }
    }
}
