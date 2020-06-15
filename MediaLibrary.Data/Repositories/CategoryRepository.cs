using MediaLibrary.CrossCutting.Models;
using MediaLibrary.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MediaLibrary.Data.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private static int records;
		private static DatabaseService service = new DatabaseService();
		private static List<SqlParameter> parameters = new List<SqlParameter>();

		public async Task<int> CreateAsync(Category task)
		{
			try
			{
				parameters.Clear();
				parameters.Add(new SqlParameter("@Name", task.Name));

				records = await service.StoredProcedureService("Sp_Category_Create", parameters);
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

		public async Task<int> DeleteAsync(int id)
		{
			try
			{
				parameters.Clear();
				parameters.Add(new SqlParameter("@Id", id));
				records = await service.StoredProcedureService("Sp_Category_Delete", parameters);
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

		public async Task<List<Category>> GetAllAsync()
		{
			List<Category> categories = new List<Category>();

			try
			{
				categories = await service.GetCategoriesAsync();
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

		public async Task<Category> GetByIdAsync(int id)
		{
			Category category = new Category();

			try
			{
				category = await service.GetCategoryByIdAsync(id);
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

		public async Task<int> UpdateAsync(Category task)
		{
			try
			{
				parameters.Clear();
				parameters.Add(new SqlParameter("@Id", task.Id));
				parameters.Add(new SqlParameter("@Name", task.Name));
				records = await service.StoredProcedureService("Sp_Category_Update", parameters);
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
