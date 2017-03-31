packages\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:testrunner.bat -register:user -filter:+[PixelFlow]*
packages\ReportGenerator.2.5.6\tools\reportgenerator.exe -reports:results.xml -targetdir:CoverageResults
move /y results.xml .\CoverageResults
move /y TestResult.xml .\TestResults