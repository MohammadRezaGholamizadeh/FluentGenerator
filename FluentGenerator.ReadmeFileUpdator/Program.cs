using DotNetReportsEngine.ReadmeGeneration;
using DotNetReportsEngine.ReadmeGeneration.Details;
using FluentGenerator;

var generatedReadme =
    new ReadmeGenerator()
        .AddAssembly(typeof(AutoServiceTools).Assembly)
        .SetProjectDetail("Fluent Generator", "This Package Is For Auto Generating The Fixture And Infrastructure That We Need To Config And Use In TDD - BDD And All Test That We Need To Run On Sql-Server And Sql-Lite and Other Database. This Package Make All Sut And Data Infrastructure And DbContext For You In Test Drivern Design Flow. Enjoy It")
        .SetLogo(new Logo()
        {
            Title = "Logo",
            LogoLink = "https://raw.githubusercontent.com/MohammadRezaGholamizadeh/FluentGenerator/main/src/FluentGenerator/Logo.ico"
        })
        .AddAuthor("@Mohammadreza Gholamizadeh [Phoenix]", "https://github.com/MohammadRezaGholamizadeh")
        .SetGitHub_AboutMe("I MohammadReza Gholamizadeh. I`m Dotnet Software Developer That Always Try To Make All things Easy for Developing. Please Star the Project And Package to Cover And Enjoy When Using It.")
        .AddGitHub_Links(new List<GitHubLink>()
        {
            new GitHubLink()
            {
                Title = "Source Code",
                LogoType = LogoLinkType.Github,
                Link = "https://github.com/MohammadRezaGholamizadeh/FluentGenerator/tree/main"
            },
            new GitHubLink()
            {
                LogoType = LogoLinkType.Github,
                Title = "MohammadReza Gholamizadeh GitHub",
                Link = "https://github.com/MohammadRezaGholamizadeh",
            },
            new GitHubLink()
            {
                LogoType = LogoLinkType.Nuget,
                Title = "Nuget",
                Link = "https://www.nuget.org/profiles/MohammadrezaGholamizadeh_Phoenix"
            }
        })
        .SetLicense(new License()
        {
            Title = "Apache-2.0 license",
            LicenseLink = "https://github.com/MohammadRezaGholamizadeh/FluentGenerator/blob/main/LICENSE"
        })
        .AddCustomText(new CustomText()
        {
            Title = "Base Requirement To Use",
            Description = "You Must Add FluentGenerator Package To Your Project That You Wrote All Your Service Test In It By These Command :"
        })
        .AddCustomBashCommand("Package Manager", @"NuGet\Install-Package FluentGenerator -Version 2024.1.0")
        .AddCustomText("Get Start To Use It",
                       "### Step 1 : " + Environment.NewLine +
                       "    Create A Generic Class And Inherit From AutoServiceConfiguration Abstract Class" + Environment.NewLine +
                       "### Step 2 : " + Environment.NewLine +
                       "    Implement The Abstract Methods With Empty Body. These Methods Are : " + Environment.NewLine +
                       "    * void ServicesConfiguration(ContainerBuilder container, Dictionary<Type, object> mockedServiceParameters, DbContext context)" + Environment.NewLine +
                       "    * DbContext SqlLiteConfiguration(SqliteConnection sqliteConnection)" + Environment.NewLine +
                       "    * DbContext SqlServerConfiguration()" + Environment.NewLine +
                       "### Step 3 :" + Environment.NewLine +
                       "    In [ServicesConfiguration] Method You Must Register All Your Service And Repository And ThirdPartyService That You Use In Your App.All Class That You Referenced In Each Class Must Be Registered Here." + Environment.NewLine +
                       "### Step 4 : " + Environment.NewLine +
                       "    In [SqlLiteConfiguration] Method You Must Config Your SqlLite DbContext To Inject To All Repository And Services That You Want To Test With Unit Tetsting Process." + Environment.NewLine +
                       "### Step 5 :" + Environment.NewLine +
                       "    In [SqlServerConfiguration] Method You Must Config Your SqlServer DbContext To Inject To All Repository And Services That You Want To Test With Integration Or Spec Flow Tetsting Process And You Want Run On SqlServer DataBase." + Environment.NewLine +
                       "### Step 6 : " + Environment.NewLine +
                       "    Create A Generic Class And Inherit From Genericc Class That You Created In Step 1. Then Implement Sut And DataContext That You Want To Use In Generic Format Like Prictures, You Must Do It Like Pictures" + Environment.NewLine +
                       "")
        .RenderAllAssembliesToText()
        .GetText();

File.WriteAllText(@$"D:\All Projects\FluentGenerator\README.md", generatedReadme);