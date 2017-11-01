using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace MyCode.Utility
{
	public class HttpHelper
	{
		private static HttpClient httpClient = new HttpClient();
		public static T GetRequest<T>(string requestUri)
		{
			T model = default(T);
			HttpResponseMessage message = httpClient.GetAsync(requestUri).Result;
			if (message.IsSuccessStatusCode)
			{
				//model = message.Content.ReadAsAsync<T>().Result;
			}
			return model;
		}
		public static string GetRequest(string requestUri)
		{
			string message = httpClient.GetStringAsync(requestUri).Result;
			return message;
		}
		public static T PostRequest<T>(string requestUri, IEnumerable<KeyValuePair<string, string>> formData)
		{

			T model = default(T);
			HttpContent content = new FormUrlEncodedContent(formData);
			HttpResponseMessage message = httpClient.PostAsync(requestUri, content).Result;
			if (message.IsSuccessStatusCode)
			{
				//model = message.Content.ReadAsAsync<T>().Result;
			}
			return model;
		}
		public static string PostRequest(string requestUri, IEnumerable<KeyValuePair<string, string>> formData)
		{
			string strResult = string.Empty;
			HttpContent content = new FormUrlEncodedContent(formData);
			HttpResponseMessage message = httpClient.PostAsync(requestUri, content).Result;
			if (message.IsSuccessStatusCode)
			{
				strResult = message.Content.ReadAsStringAsync().Result;
			}
			return strResult;

		}
		public static string CreateQueryString<T>(T model, string requestUri = null) where T : class
		{
			var Properties = model.GetType().GetProperties();
			StringBuilder sb = new StringBuilder(Properties.Count());
			foreach (var item in Properties)
			{
				string name = item.Name;
				string value = Convert.ToString(item.GetValue(model));
				sb.AppendFormat("&{0}={1}", name, value);
			}
			sb.Remove(0, 1);
			if (!string.IsNullOrEmpty(requestUri))
				sb.Insert(0, requestUri + "?");
			return sb.ToString();
		}
	}
}