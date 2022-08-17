using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeCloud.LES.ClassLibrary.Core.Helpers
{
	public static class Base64Helper
	{
		public static string ToBase64Encode(this string plainText)
		{
			var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			return System.Convert.ToBase64String(plainTextBytes);
		}
		public static string ToBase64Decode(this string base64EncodedData)
		{
			var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(base64EncodedBytes);
		}
	}
}
