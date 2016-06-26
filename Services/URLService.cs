using Agap.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using URLShortener.Models;
using URLShortener.Models.Domain;
using URLShortener.Services.Interfaces;

namespace URLShortener.Services
{//Inheriting base service and Implementing IURLService
    public class URLService : BaseService, IURLService
    {
        public int Insert(URLRequestModel model)
        {
            int uid = 0;
            string slug = UtilityService.MakeSlug(8);
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.URL_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@URL", model.URL);


                   SqlParameter p = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;
                   paramCollection.Add(p);

                   paramCollection.AddWithValue("@Slug", slug); //created by utility service

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   //ID is coming back as a string and its parsing it into an integer.
                   int.TryParse(param["@ID"].Value.ToString(), out uid);//pull out whatever the proc returns as a string and turn it into a number
               }
               );


            return uid;
        }

        // Get URL by Slug String for reverse conversion
        public URL GetBySlug(string slug)
        {
            URL item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.GetURLbySlug"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Slug", slug);


               }, map: delegate (IDataReader reader, short set)
               {
                   item = new URL();
                   int startingIndex = 0; //startingOrdinal
                   item.ID = reader.GetInt32(startingIndex++);
                   item.Url = reader.GetSafeString(startingIndex++);
                   item.Slug = reader.GetSafeString(startingIndex++);
                   item.Created = reader.GetSafeDateTime(startingIndex++);
               }
               );

            return item;
        }

        // Get URL by Slug String for reverse conversion
        public URL GetByUrl(string url)
        {
            URL item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.GetSlugByUrl"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Url", url);


               }, map: delegate (IDataReader reader, short set)
               {
                   item = new URL();
                   int startingIndex = 0; //startingOrdinal
                   item.ID = reader.GetInt32(startingIndex++);
                   item.Url = reader.GetSafeString(startingIndex++);
                   item.Slug = reader.GetSafeString(startingIndex++);
                   item.Created = reader.GetSafeDateTime(startingIndex++);
               }
               );

            return item;
        }
    }
}