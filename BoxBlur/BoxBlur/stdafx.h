// stdafx.h : 标准系统包含文件的包含文件，或是经常使用但不常更改的特定于项目的包含文件

#pragma once					//	这是一个比较常用的C/C++杂注，只要在头文件的最开始加入这条杂注，就能够保证头文件只被编译一次。
								//	#pragma once是编译器相关的，有的编译器支持，有的编译器不支持，具体情况请查看编译器API文档，不过现在大部分编译器都有这个杂注了。
#define WIN32_LEAN_AND_MEAN     //  从 Windows 头文件中排除极少使用的信息
#include <windows.h>			//	WINDOWS.H是一个最重要的头文件，它包含了其他Windows头文件，这些头文件的某些也包含了其他头文件。
#include <SDKDDKVer.h>			//	将定义的可用的最高版本的Windows平台
