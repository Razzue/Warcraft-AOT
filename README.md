# Warcraft AOT
Full C# internal library for World of Warcraft (Classic and Retail) utilizing .Net7 and NativeAOT.




# Build Instructions

### Glass Cannon
1. Set project configuration to `Release` and `x64`.
2. Right click the project and open the `Publish` option.
3. Select the folder option, and enter your desired publish directory.
4. Open `Show all settings` in the new publish tab, and set the following:
| Option | Value |
| :-------- | :------- |
| Configuration | Release\|x64 |
| Target Runtime | win-x64 |
| ReadyToRun compilation | checked |

5. Open `/PublishProfiles/FolderProfile.pubxml` and insert `<PublishAot>true</PublishAot>`.
6. Publish the project and hope for the best!

### Loader
1. Set project configuration to `Release` and `x64`.
2. Set the path of the DLL to inject.
3. Build and run!
# Mentions
VollRagm: [KernelBypassSharp]("https://github.com/VollRagm/KernelBypassSharp/") -> For introducing me to NativeAOT.

ZeroLP: [SharpNativeDLL]("https://github.com/ZeroLP/SharpNativeDLL") -> For introducing me to a template for my projects going forward. 

Because of these individuals, I achieved something i was always told was "impossible".
## Disclaimer

This is strictly for educational purposes only (and, of course, for a little fun).
I do not take any responsibility for any account actions that occurr using the methods provided.
## License
This project is licensed under the terms of the [GNU AGPLv3](https://choosealicense.com/licenses/agpl-3.0/) license.
