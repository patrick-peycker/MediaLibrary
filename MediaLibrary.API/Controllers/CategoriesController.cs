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
	public class CategoriesController : ApiController
	{
		private static CategoryRepository repository = new CategoryRepository();

		// GET: api/Categories
		public async Task<IEnumerable<Category>> GetAsync()
		{
			List<Category> categories;

			try
			{
				categories = await repository.GetAllAsync();
			}

			catch (SqlException ex)
			{
				throw ex;
			}

			catch (Exception ex)
			{
				throw ex;
			}

			return categories;
		}

		// GET: api/Categories/5
		public async Task<Category> GetAsync(int id)
		{
			Category category;

			try
			{
				category = await repository.GetByIdAsync(id);
			}

			catch (SqlException ex)
			{
				throw ex;
			}

			catch (Exception ex)
			{
				throw ex;
			}

			return category;
		}

		// POST: api/Categories
		public async Task<int> Post([FromBody] string task)
		{
			int records;

			try
			{
				records = await repository.CreateAsync(JsonConvert.DeserializeObject<Category>(task));
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

		// PUT: api/Categories/5
		public async Task<int> Put([FromBody] string task)
		{
			int records;

			try
			{
				records = await repository.UpdateAsync(JsonConvert.DeserializeObject<Category>(task));
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

		// DELETE: api/Categories/5
		public async Task<int> Delete(int id)
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
