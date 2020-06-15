using MediaLibrary.CrossCutting.Enumerations;
using MediaLibrary.CrossCutting.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MediaLibrary.Data
{
	public class DatabaseService
	{
		private static SqlConnection connection = new SqlConnection();
		private static SqlCommand command = new SqlCommand();

		public DatabaseService()
		{
			connection.ConnectionString = "Server=(local); Database=MediaLibrary; User Id=User; Password=User";
			//connection.ConnectionString = "name=MediaLibrary";
		}

		public async Task<int> StoredProcedureService(string storedProcedure, List<SqlParameter> parameters)
		{
			int records;

			try
			{
				command.CommandText = storedProcedure;
				command.CommandType = CommandType.StoredProcedure;

				foreach (var parameter in parameters)
				{
					command.Parameters.Add(parameter);
				}

				command.Connection = connection;
				connection.Open();
				records = await command.ExecuteNonQueryAsync();
			}

			catch (SqlException ex)
			{

				throw ex;
			}

			catch (Exception ex)
			{
				throw ex;
			}

			finally
			{
				connection.Close();
			}

			return records;
		}

		public async Task<List<Media>> GetMediasAsync()
		{
			List<Media> medias = new List<Media>();

			try
			{
				command.CommandText = "select * from View_Medias";
				command.CommandType = CommandType.Text;

				command.Connection = connection;
				connection.Open();

				SqlDataReader response = await command.ExecuteReaderAsync();

				while (response.Read())
				{
					Media media = new Media();
					media.Id = response.GetInt32(0);
					media.Name = response.GetString(1);
					media.Url = response.GetString(2);
					media.Placement = response.GetString(3);
					media.Type = (TypeObject) response.GetInt32(4);
					media.Done = response.GetBoolean(5);
					media.CategoryId = response.GetInt32(6);
					media.CategoryName = response.GetString(7);
					medias.Add(media);
				}

			}

			catch (SqlException ex)
			{
				throw ex;
			}

			catch (Exception ex)
			{
				throw ex;
			}

			finally
			{
				connection.Close();
			}

			return medias;
		}

		public async Task<Media> GetMediaByIdAsync (int id)
		{
			Media media = new Media();

			try
			{
				command.CommandText = "select * from View_Medias where Med_Id = {id}";
				command.CommandType = CommandType.Text;

				command.Connection = connection;
				connection.Open();

				SqlDataReader response = await command.ExecuteReaderAsync();

				while (response.Read())
				{
					media.Id = response.GetInt32(0);
					media.Name = response.GetString(1);
					media.Url = response.GetString(2);
					media.Placement = response.GetString(3);
					media.Type = (TypeObject) response.GetInt32(4);
					media.Done = response.GetBoolean(5);
					media.CategoryId = response.GetInt32(6);
					media.CategoryName = response.GetString(7);
				}

			}

			catch (SqlException ex)
			{
				throw ex;
			}

			catch (Exception ex)
			{
				throw ex;
			}

			finally
			{
				connection.Close();
			}

			return media;
		}

		public async Task<List<Category>> GetCategoriesAsync()
		{
			List<Category> categories = new List<Category>();

			try
			{
				command.CommandText = "select * from View_Categories";
				command.CommandType = CommandType.Text;

				command.Connection = connection;
				connection.Open();

				SqlDataReader response = await command.ExecuteReaderAsync();

				while (response.Read())
				{
					Category category = new Category();
					category.Id = response.GetInt32(0);
					category.Name = response.GetString(1);
					categories.Add(category);
				}

			}

			catch (SqlException ex)
			{
				throw ex;
			}

			catch (Exception ex)
			{
				throw ex;
			}

			finally
			{
				connection.Close();
			}

			return categories;
		}

		public async Task<Category> GetCategoryByIdAsync(int id)
		{
			Category category = new Category();

			try
			{
				command.CommandText = "select * from View_Categories where Cat_Id = {id}";
				command.CommandType = CommandType.Text;

				command.Connection = connection;
				connection.Open();

				SqlDataReader response = await command.ExecuteReaderAsync();

				while (response.Read())
				{
					category.Id = response.GetInt32(0);
					category.Name = response.GetString(1);
				}

			}

			catch (SqlException ex)
			{
				throw ex;
			}

			catch (Exception ex)
			{
				throw ex;
			}

			finally
			{
				connection.Close();
			}

			return category;
		}
	}
}
