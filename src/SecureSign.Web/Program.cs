﻿/**
 * Copyright (c) 2017 Daniel Lo Nigro (Daniel15)
 * 
 * This source code is licensed under the MIT license found in the 
 * LICENSE file in the root directory of this source tree. 
 */

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SecureSign.Core.Extensions;

namespace SecureSign.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration(builder => builder.AddSecureSignConfig())
				.ConfigureKestrel(options =>
				{
					options.Limits.MaxRequestBodySize = Constants.MAX_ARTIFACT_SIZE;
				})
				.UseStartup<Startup>();
	}
}
