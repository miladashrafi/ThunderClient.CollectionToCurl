# ThunderClient.CollectionToCurl

Bulk convert "Thunder Client" collection requests to single CURL files.


---

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Exporting Collections from Thunder Client](#exporting-collections-from-thunder-client)
- [Contributing](#contributing)
- [License](#license)

---

## Introduction

**ThunderClient.CollectionToCurl** is a console application developed in C# .NET 7. It allows you to efficiently convert exported collections from the Thunder Client VSCode extension into individual CURL-formatted text files. These CURL files can be easily used in any API client tool or serve as a backup of your organized HTTP calls.

Thunder Client is a popular VSCode extension used for making API calls, performing API tests, and facilitating API development, much like POSTMAN. With this tool, you can seamlessly transition your Thunder Client collections into standalone CURL files, streamlining your API development workflow and ensuring your HTTP requests are easily portable and maintainable.

---

## Features

- Bulk conversion of Thunder Client collections into individual CURL files.
- Organize HTTP requests within folders for better management.
- Seamless transition of Thunder Client collections for use in other API client tools.
- Provides a backup of your Thunder Client collections for free.
- Open-source and community-driven for continuous improvement.

---

## Installation

To use **ThunderClient.CollectionToCurl**, follow these simple steps:

1. Clone this repository to your local machine using the following command:

    ```bash
    git clone https://github.com/miladashrafi/ThunderClient.CollectionToCurl.git
    ```

2. Build the project using your preferred C# .NET 7 development environment.

3. Once the project is built, you can execute the application from the command line.

---

## Usage

After successfully building the application, you can run it from the command line with the following command:

```bash
dotnet ThunderClient.CollectionToCurl.dll
```
The application will prompt you to enter key to start processing collection files in "Collections" folder you wish to convert. 
It will then create a corresponding folder structure and save individual CURL files for each request within the collections.

---

## Exporting Collections from Thunder Client

To export your Thunder Client collections, follow these steps:

1. Open Thunder Client in Visual Studio Code.
2. Select the collection you want to export.
3. Click on the "Export" button in the Thunder Client interface.
4. Choose the "JSON" format for exporting.
5. Save the exported JSON file in a folder on your computer.
6. Copy the exported JSON file into the "Collections" folder within the ThunderClient.CollectionToCurl application directory.
7. Run the ThunderClient.CollectionToCurl application as described in the "Usage" section.

---

## Contributing

Contributions are welcome! If you have any suggestions, feature requests, or bug reports, please open an issue on the GitHub repository. If you'd like to contribute code, feel free to fork the repository, make your changes, and submit a pull request.

For more details on contributing, please refer to the CONTRIBUTING.md file.

---

## License

This project is licensed under the MIT License. You are free to use, modify, and distribute this software as per the terms of the license.

Thank you for using **ThunderClient.CollectionToCurl**. We hope this tool simplifies your API development and management process. If you have any questions or feedback, please don't hesitate to reach out.

Happy coding!

Owner & Developer: @miladashrafi
