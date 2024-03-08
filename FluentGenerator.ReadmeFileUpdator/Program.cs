using DotNetReportsEngine.ReadmeGeneration;
using DotNetReportsEngine.ReadmeGeneration.Details;
using FluentGenerator;

var generatedReadme =
    new ReadmeGenerator()
        .AddAssembly(typeof(AutoServiceTools).Assembly)
        .SetProjectDetail("Fluent Generator", "This Package Is For Auto Generating The Fixture And Infrastructure That We Need To Config And Use In TDD - BDD And All Test That We Need To Run On Sql-Server And Sql-Lite and Other Database. This Package Make All Sut And Data Infrastructure And DbContext For You In Test Drivern Design Flow" + Environment.NewLine +
        "This Is The Best Tools For Test Driven Design [TDD] And Behavior Driven Design [BDD] And Spec Flow Test [SpecFlow - ATDD] . Enjoy It" + Environment.NewLine)
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
                LogoType = LogoLinkType.CustomLink,
                Title = "Readme File",
                Link = "https://github.com/MohammadRezaGholamizadeh/FluentGenerator/blob/main/README.md",
            },
            new GitHubLink()
            {
                LogoType = LogoLinkType.Nuget,
                Title = "Nuget",
                Link = "https://www.nuget.org/profiles/MohammadrezaGholamizadeh_Phoenix"
            },
            new GitHubLink()
            {
                LogoType = LogoLinkType.LinkedIn,
                Title = "LinkedIn",
                Link = "https://www.linkedin.com/in/mohammadreza-gholamizadeh-b94b1521b/"
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
        .AddCustomText("Get Start To Use It", "")
        .AddCustomText("# Step 1", "Create A Generic Class And Inherit From AutoServiceConfiguration Abstract Class")
        .AddCustomText("# Step 2", "Implement The Abstract Methods With Empty Body. These Methods Are : " + Environment.NewLine +
                                   "* void ServicesConfiguration(ContainerBuilder container, Dictionary<Type, object> mockedServiceParameters, DbContext context)" + Environment.NewLine +
                                   "* DbContext SqlLiteConfiguration(SqliteConnection sqliteConnection)" + Environment.NewLine +
                                   "* DbContext SqlServerConfiguration()" + Environment.NewLine)
        .SetLogo("Step1", "https://raw.githubusercontent.com/MohammadRezaGholamizadeh/FluentGenerator/main/FluentGenerator.ReadmeFileUpdator/Files/AutoServiceCreator.png")
        .AddCustomText("# Step 3", "In [ServicesConfiguration] Method You Must Register All Your Service And Repository " + Environment.NewLine +
                                   "And ThirdPartyService That You Use In Your App.All Class That You Referenced In Each Class " + Environment.NewLine +
                                   "Must Be Registered Here." +
                                   "When You Are Registering Services And All Part Of Application you Must Use These Method " + Environment.NewLine +
                                   "To Pass DbContext Or Mocked Object To Them To Use." +
                                   "This Methods Is [.WithDbContext(context as DbContext)] And [.WithConstructorParameters(mockedServiceParameters)]" + Environment.NewLine)
        .AddCustomText("# Step 4", "In [SqlLiteConfiguration] Method You Must Config Your SqlLite DbContext To Inject To All Repository " + Environment.NewLine +
                                   "And Services That You Want To Test With Unit Tetsting Process." + Environment.NewLine)
        .AddCustomText("# Step 5", "In [SqlServerConfiguration] Method You Must Config Your SqlServer DbContext " + Environment.NewLine +
                                   "To Inject To All Repository And Services That You Want To Test With Integration Or Spec Flow Tetsting " + Environment.NewLine +
                                   "Process And You Want Run On SqlServer DataBase." + Environment.NewLine)
        .AddCustomText("# Step 6", "Create A Generic Class And Inherit From Generic Class That You Created In Step 1." + Environment.NewLine +
                                   "Then Implement Sut And DataContext That You Want To Use In Generic Format Like Prictures, " + Environment.NewLine +
                                   "You Must Do It Like Pictures And All You Need To Add In It." + Environment.NewLine)
        .SetLogo("Step6", "https://raw.githubusercontent.com/MohammadRezaGholamizadeh/FluentGenerator/main/FluentGenerator.ReadmeFileUpdator/Files/UnitSut.png")
        .SetLogo("Step6", "https://raw.githubusercontent.com/MohammadRezaGholamizadeh/FluentGenerator/main/FluentGenerator.ReadmeFileUpdator/Files/IntegrationSut.png")
        .AddCustomText("# Step 7", "Create A Generic Class And Inherit From Genericc Class That You Created In Step 1. " + Environment.NewLine +
                                   "Then Implement Sut And DataContext That You Want To Use In Generic Format Like Prictures, You Must Do It Like Pictures" + Environment.NewLine +
                                   "If You Want To Use SqlLite Configuration that You Configured In Previous Step You Must Use DataBaseType.SqlLiteDataBase In CreateService Method" + Environment.NewLine +
                                   "And If You Want To Use SqlServer Configuration that You Configured In Previous Step You Must Use DataBaseType.SqlServerDataBase Instead." + Environment.NewLine)
        .AddCustomText("# Step 8", "Go To Your Test Class And Inherit From Generic Class That Create And Configured Your SUT And DbContext In It " + Environment.NewLine +
                                   "And In Generic Parameter You Must Use Your Sut Interface That You Want To Test Like Pictures :" + Environment.NewLine)
        .SetLogo("Step8", "https://raw.githubusercontent.com/MohammadRezaGholamizadeh/FluentGenerator/main/FluentGenerator.ReadmeFileUpdator/Files/UnitSutInTest.png")
        .SetLogo("Step8", "https://raw.githubusercontent.com/MohammadRezaGholamizadeh/FluentGenerator/main/FluentGenerator.ReadmeFileUpdator/Files/IntegrtionSutInTest.png")
        .AddCustomText("# Step 9", "If You Need To Use Mock Objects In Your Sut So You Must Do Like This Picture : " + Environment.NewLine)
        .SetLogo("Step9", "https://raw.githubusercontent.com/MohammadRezaGholamizadeh/FluentGenerator/main/FluentGenerator.ReadmeFileUpdator/Files/WhenWeWantToUseMock.png")
        .AddCustomText("Step 10", "Now You Must Add A Json File Whit Exactly Name [dataBaseSettings.json] that Contains Connection String In Static Format Exactly Like Pictures " + Environment.NewLine +
                                  "And Most Registered In .cjproj File: This Is Your Test Data Base Connection String." + Environment.NewLine)
        .SetLogo("Step9", "https://raw.githubusercontent.com/MohammadRezaGholamizadeh/FluentGenerator/main/FluentGenerator.ReadmeFileUpdator/Files/Pic5.png")
        .RenderAllAssembliesToText()
        .GetText();

File.WriteAllText(@$"D:\All Projects\FluentGenerator\README.md", generatedReadme);