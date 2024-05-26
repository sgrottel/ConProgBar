# SGrottel.ConProgBar
A simple progress bar for the text console.

https://github.com/sgrottel/ConProgBar

## Example
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
```

## License
The code is freely available under terms of the Apache License V2 (see [LICENSE](./License))

> Copyright 2022-2024 SGrottel
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
