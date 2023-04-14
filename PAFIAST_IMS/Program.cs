using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using PAFIAST_IMS.Data;
using System.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Wkhtmltopdf.NetCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PAFIAST_IMSContextConnection");
builder.Services.AddControllers();
builder.Services.AddDbContext<PAFIAST_IMSContext>(options =>
    options.UseSqlServer(connectionString));;
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PAFIAST_IMSContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

/*builder.Services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<PAFIAST_IMSContext>();*/
builder.Services.AddDbContext<PAFIAST_IMSContext>(options =>
     options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<PAFIAST_IMSContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddWkhtmltopdf("wkhtmltopdf");
builder.Services.AddRazorPages().AddMicrosoftIdentityUI();
builder.Services.AddRouting();
var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ?? builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
        .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
            .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
            .AddInMemoryTokenCaches();
/*builder.Services.AddMvc(option =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    option.Filters.Add(new AuthorizeFilter());
});*/
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin-only", p =>
    {
        p.RequireClaim("groups", "c07a262e-6b78-4eb5-91f6-406ab2bc4493");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())   
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    //For identity
    endpoints.MapRazorPages();  //this line causes issue
});
app.MapRazorPages();

app.Run();
