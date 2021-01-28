**Feature description**
* Clearly and concisely describe the problem or feature (this cannot be empty).

 **Analysis and design**
* If there is an external design, link to its project documentation area.
* If there is an internal discussion on the forum, provide the link.
 
**Solution description**
* Describe your code changes in detail for reviewers.

**Areas affected and ensured**
* List the areas are affected by your code changes.

**Additional checklist**
* [ ] Does it follow the design [guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/)? It is mandatory that, we should not move the changes without reading this.
* [ ] Properly working in Xamarin.Forms [previewer](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/xaml/xaml-previewer?tabs=vswin).
* [ ] Ensured in iOS, Android, UWP and macOS (if supported).
* [ ] Doesn’t have memory leak. Please check the list of items to be ensured [here](https://syncfusion.atlassian.net/wiki/spaces/XAMRIN/pages/880875734/Memory+Leak).
* [ ] Have you added  [Preserve](https://syncfusion.atlassian.net/wiki/spaces/XAMRIN/pages/192124218/Guidelines+for+adding+Preserve+attribute) attribute if needed?
* [ ] Have you ensured the changes in Android API 19 and iOS 9?
