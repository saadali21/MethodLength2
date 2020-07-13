SonarQube custom rules

SonarQube has a set of rules for each programming language, the rule can be activated or disactivated but cannot be modified. That's why if you want to add a new rule (your custom rule) you need to create and add it yourself.

But before thet check the existing rules on sonarQube website, The following link contains all the rules for all supported language in SonarQube:
https://rules.sonarsource.com/csharp/RSPEC-5542 

The following are the steps to add a custom SonarQube rule to the server:

Create custom rules using Roslyn, by following the tutorial of Microsoft https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/tutorials/how-to-write-csharp-analyzer-code-fix 
/* Make sure the analyzer installed of version Roslyn 2.8.2 or lower (otherwise step 4 will fail)
Publish the analyzer (the rule) as a NuGet package.
Publish the NuGet package (NuGet account needed).
Use SonarQube Roslyn SDK project to generate the .jar file from the NuGet package https://github.com/SonarSource/sonarqube-roslyn-sdk 
The generated jar can be installed to SonarQube as normal (e.g. by dropping it in the SonarQube server extensions\plugins folder and restarting the SonarQube server). You will see a new repository containing all of the rules defined by the analyzer. The rules can be added to Quality Profiles just like any other SonarQube rule. The folder path on the server is D:\Apps\SonarQube\sonarqube-7.9.1\extensions\plugins
The new rule will be added to the set of rules but not activated, you can find it based on the language and the category of the rule (Blocker, Minor…)
