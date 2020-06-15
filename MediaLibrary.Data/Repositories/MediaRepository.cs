using MediaLibrary.CrossCutting.Models;
using MediaLibrary.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MediaLibrary.Data.Repositories
{
	public class MediaRepository : IMediaRepository
	{
		private static int records;
		private static DatabaseService service = new DatabaseService();
		private static List<SqlParameter> parameters = new List<SqlParameter>();

		public async Task<int> CreateAsync(Media task)
		{
			try
			{
				parameters.Clear();
				parameters.Add(new SqlParameter("@Name", task.Name));
				parameters.Add(new SqlParameter("@Url", task.Url));
				parameters.Add(new SqlParameter("@Placement", task.Placement));
				parameters.Add(new SqlParameter("@Type", task.Type));
				parameters.Add(new SqlParameter("@Done", task.Done));
				parameters.Add(new SqlParameter("@Cat_Id", task.CategoryId));

				records = await service.StoredProcedureService("Sp_Media_Create", parameters);
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
				records = await service.StoredProcedureService("Sp_Media_Delete", parameters);
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

		public async Task<List<Media>> GetAllAsync()
		{
			List<Media> medias = new List<Media>();

			try
			{
				medias = await service.GetMediasAsync();
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

		public async Task<Media> GetByIdAsync(int id)
		{
			Media media = new Media();

			try
			{
				media = await service.GetMediaByIdAsync(id);
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

		public async Task<int> UpdateAsync(Media task)
		{
			try
			{
				parameters.Clear();
				parameters.Add(new SqlParameter("@Id", task.Id));
				parameters.Add(new SqlParameter("@Name", task.Name));
				parameters.Add(new SqlParameter("@Url", task.Url));
				parameters.Add(new SqlParameter("@Placement", task.Placement));
				parameters.Add(new SqlParameter("@Type", task.Type));
				parameters.Add(new SqlParameter("@Done", task.Done));
				parameters.Add(new SqlParameter("@Cat_Id", task.CategoryId));

				records = await service.StoredProcedureService("Sp_Media_Update", parameters);
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
