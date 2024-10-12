namespace H_Shopping.ExtendMethods
{
	public static class AppExtend
	{
		public static void AddStatusCodePage(this IApplicationBuilder app)
		{
			app.UseStatusCodePages(appError =>
			{
				appError.Run(async context =>
				{
					var response = context.Response;
					var statusCode = response.StatusCode;

					var content = $@"<!DOCTYPE html>
                            <html lang=""vi"">

                            <head>
                                <meta charset=""UTF-8"">
                                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                <title>404 Not Found</title>
                                <style>
                                    .page_404 {{
                                        padding: 40px 0;
                                        background: #fff;
                                        font-family: 'Roboto', sans-serif;
                                    }}

                                    .page_404 img {{
                                        width: 100%;
                                    }}

                                    .four_zero_four_bg {{

                                        background-image: url(https://cdn.dribbble.com/users/285475/screenshots/2083086/dribbble_1.gif);
                                        background-repeat: no-repeat;
                                        height: 400px;
                                        background-position: center;
                                    }}


                                    .four_zero_four_bg h1 {{
                                        font-size: 80px;
                                    }}

                                    .four_zero_four_bg h3 {{
                                        font-size: 80px;
                                    }}

                                    .link_404 {{
                                        color: #fff !important;
                                        padding: 10px 20px;
                                        background: #FE980F;
                                        margin: 20px 0;
                                        display: inline-block;
                                    }}

                                    .contant_box_404 {{
                                        margin-top: -50px;
                                    }}
                                </style>
                            </head>

                            <body>
                                <section class=""page_404"">
                                    <div class=""container"">
                                        <div>
                                            <div style=""text-align: center;"">
                                                <div>
                                                    <div class=""four_zero_four_bg"">
                                                        <h1 class=""text-center "">404</h1>


                                                    </div>

                                                    <div class=""contant_box_404"">
                                                        <h3 class=""h2"">
                                                            Look like you're lost
                                                        </h3>

                                                        <p>the page you are looking for not avaible!</p>

                                                        <a href=""/Home"" style=""text-decoration: none;"" class=""link_404"">Go to Home</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </body>

                            </html>";

					await response.WriteAsync(content);
				});
			});
		}
	}
}
