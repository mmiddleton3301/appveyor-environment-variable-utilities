# AppVeyor Environment Variable Utilities
[![Build status](https://ci.appveyor.com/api/projects/status/utstv5d6xj7ok2gb?svg=true)](https://ci.appveyor.com/project/mmiddleton3301/appveyor-environment-variable-utilities)

A console application (and C# library) that uses the AppVeyor API to compare multiple different deployment environments and their environment variables.

This utility can also be used to back up your environment variables for your various AppVeyor deployment environments.

## Installation
### Chocolatey
`appveyor-evu` will be available via chocolatey. When the first version of the package has been approved, then details on how to install will be included here.

## Manually
If you don't want to use chocolatey, `appveyor-evu` can be downloaded and "installed" manually: just download the latest release from GitHub, unzip the contents of the archive to a directory of your choosing, and start your command line from that directory. Invoke `appveyor-evu` at your leisure.

## Usage
Simply invoke `appveyor-evu` to view the options available:

    --apitoken             Required. An AppVeyor API token.

    --environments         Required. A list of AppVeyor environment names.

    --outputcsvlocation    Required. The location in which to output environment variables when comparing.

    --verbosity            (Default: Warn) Specify the verbosity of output from the application. Valid options are: "Debug", "Info", "Warn", "Error", "Fatal" or "Off".

    --help                 Display this help screen.

    --version              Display version information.

Example:

    appveyor-evu --apitoken "123abc" --environments "dev-somecorpapp" "uat-somecorpapp" "prod-somecorpapp" --outputcsvlocation "details.csv"
    
### AppVeyor API token
You can view your AppVeyor API token by logging in and visiting:

https://ci.appveyor.com/api-token
