# ConProgBar
A simple progress bar for the text console.

For both C++ and CSharp simply add the required file to your project.
For C++, this is a single header file.

[![GitHub License](https://img.shields.io/github/license/sgrottel/ConProgBar)](./License)
[![NuGet Version](https://img.shields.io/nuget/v/SGrottel.ConProgBar.CSharp?logo=nuget&label=CSharp%20Nuget&color=green)](https://www.nuget.org/packages/SGrottel.ConProgBar.CSharp/)
[![CSharp Windows](https://github.com/sgrottel/ConProgBar/actions/workflows/csharp-windows.yaml/badge.svg)](https://github.com/sgrottel/ConProgBar/actions/workflows/csharp-windows.yaml)
[![CSharp Ubuntu](https://github.com/sgrottel/ConProgBar/actions/workflows/csharp-ubuntu.yaml/badge.svg)](https://github.com/sgrottel/ConProgBar/actions/workflows/csharp-ubuntu.yaml)
[![Cpp Windows](https://github.com/sgrottel/ConProgBar/actions/workflows/cpp-windows.yaml/badge.svg)](https://github.com/sgrottel/ConProgBar/actions/workflows/cpp-windows.yaml)

## C# Usage Example

Add `ConProgBar.cs` and optionally `TaskbarProgress.cs` to your project.

```csharp
ConProgBar bar = new();
bar.MaximumWidth = Console.WindowWidth - 1;
bar.MinimumWidth = bar.MaximumWidth;

bar.Show = true;

for (int i = 0; i < maxI; ++i)
{
	bar.Value = (double)i / maxI;

	Thread.Sleep(500);

	if (i == 10)
	{
		bar.Show = false;
		Console.WriteLine("Intermission...");
		Thread.Sleep(2000);
		bar.Show = true;
	}
}

bar.Show = false;

Console.WriteLine("Done.");
```

## C++ Usage Example

Just add `ConProgBar.hpp` to your project.

```cpp
#include "ConProgBar.hpp"

// ...

sgconutil::ConProgBar<int> bar;

// Start the bar with any progress value range.
// The max value indicates process completion.
bar.Start(0, 10, 0);

for (int i = 0; i < 10; ++i) {
	bar.SetVal(i);

	// Do your stuff

}

// And, we are done.
bar.Complete();
```

All three function calls will report their progress information to `std::cout`.
For best, consistent output, your application should not output any information (except for critical errors, of course).
If you do, be sure to add a new line to your output, as a subsequence output from the ConProgBar will start with a `\r`.


## License
The code is freely available under terms of the Apache License V2 (see [LICENSE](./License))

> Copyright 2022-2025 SGrottel
>
> Licensed under the Apache License, Version 2.0 (the "License");
> you may not use this file except in compliance with the License.
> You may obtain a copy of the License at
>
> http://www.apache.org/licenses/LICENSE-2.0
>
> Unless required by applicable law or agreed to in writing, software
> distributed under the License is distributed on an "AS IS" BASIS,
> WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
> See the License for the specific language governing permissions and
> limitations under the License.
