using System;
using System.Diagnostics;
using Foundation;
using Security;

namespace rnApp
{
	public class KeyValueManager
	{
		public KeyValueManager()
		{
		}

		private void SaveRecord( String strKey, String strValue)
		{
			var record = new SecRecord(SecKind.GenericPassword)
			{
				//Label = "交易密碼",
				//Description = "用於xxx服務",
				//Account = "liddle.fang@gmail.com",
				//Service = "Transcation",
				//Comment = "Demo",
				ValueData = NSData.FromString(strValue),
				Generic = NSData.FromString(strKey)
			};

			var status = SecKeyChain.Add(record);

			if (SecStatusCode.Success == status)
			{
				Debug.WriteLine("Keychain Saved!");
			}
			else if (SecStatusCode.DuplicateItem == status || SecStatusCode.DuplicateKeyChain == status)
			{
				Debug.WriteLine("Duplicate !");
				SecKeyChain.Remove(record);
			}
			else {
				Debug.WriteLine($"{ status }");
			}

		}

		private string QueryRecord( String srKey )
		{

			SecStatusCode status;

			var rec = new SecRecord(SecKind.GenericPassword)
			{
				Generic = NSData.FromString(srKey)
			};

			var match = SecKeyChain.QueryAsRecord(rec, out status);

			if (SecStatusCode.Success == status && null != match)
			{

				Debug.WriteLine($"{match.Account};{match.ValueData.ToString()}");

				return match.Account;
			}

			Debug.WriteLine("Nothing found.");
			return string.Empty;

		}

		private void SaveNSDefaults( String strKey, String strValue )
		{

			//var message = "Hello, Xamarin!";

			NSUserDefaults.StandardUserDefaults.SetString(strValue, strKey );
			NSUserDefaults.StandardUserDefaults.Synchronize();

			Debug.WriteLine($"{ strValue } Saved!");
		}

		private string ReadNSDefaults(String strKey)
		{
			var stored = NSUserDefaults.StandardUserDefaults.StringForKey(strKey);

			Debug.WriteLine($"stored:{stored}!");

			return stored;
		}
	}
}

