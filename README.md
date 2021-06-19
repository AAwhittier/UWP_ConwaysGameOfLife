# Overview

This is Conway's Game of Life created on UWP using the Win2D runtime graphics API.
This game follows the rules as Conway created them:
1. A cell with 2/3 living neighbors stays alive.
2. A dead cell with 3 live neighbors becomes alive.
3. When the next generation is decided all other living cells are killed.

This implementation assigns a random game board for the initial state and then
follows the rules as Conway laid them out. I wrote this to begin learning the UWP
platform and the tools associated with it.

* [Software Demo Video](https://youtu.be/tn_l5ZCN8GY)

# Development Environment

Created in Visual Studio 2019 using Win2D for graphics.

* [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm)

# Useful Websites

* [Rendering](https://docs.microsoft.com/en-us/windows/uwp/gaming/tutorial--assembling-the-rendering-pipeline)
* [Invalidate Drawing Controls](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.invalidate?view=net-5.0)

# Future Work

* Add pause/play functionality.
* Allow used to enable/disable cells.
* Show generation count.
