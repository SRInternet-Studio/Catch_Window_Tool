
<div align="center">
<br>
<img src='https://raw.githubusercontent.com/SRInternet-Studio/Catch_Window_Tool/main/%E6%8A%93%E5%8F%96%E7%AA%97%E5%8F%A3.ico' alt='en-ico' height="100" width="100"></img>
<h1>抓取窗口工具 🪄</h1>
</div> 

## 详细信息
### 介绍
使开发者调试更方便，无需操作，直接抓取焦点窗口信息 ✨

### 软件架构及编写环境
- 架构：.NET Framework 4.7.2 （包含 .NET Runtime）
- 语言：Visual Basic.NET
> 需要.NET Framework (可以在这里[下载](https://download.visualstudio.microsoft.com/download/pr/1f5af042-d0e4-4002-9c59-9ba66bcf15f6/089f837de42708daacaae7c04b7494db/ndp472-kb4054530-x86-x64-allos-enu.exe))

### 兼容性
Windows 7 SP1 - Windows 11，Windows 11 以上也可以使用。

### 使用图示
![正在抓取窗口的工具](https://github.com/user-attachments/assets/decaa428-f8ba-496c-9395-79bb9f5ef44c)

[Buy us a coffee!](https://afdian.net/a/srinternet)

[Follow us（Douyin）](https://www.douyin.com/user/MS4wLjABAAAATzdjtBBrLLCn69TtPMeseuEUzztbNZzw-9f13adrfiM?relation=0&vid=7143257533807873316)

[Follow us（Bilibili）](https://space.bilibili.com/1969160969?spm_id_from=333.1007.0.0)

[Follow us（Youtube）](https://www.youtube.com/channel/UCEPXlJTTAoKun8cYY1ix3ew)

## 使用说明
1. 双击打开 Catch_Window_Tool.exe (可能会弹出UAC，需要点击**确认**）
2. 将鼠标聚焦到需要抓取信息的窗口
3. 你可以看到该窗口的信息

### 前言：为何开源
因为这个工具只是为大家提供一个开发工具的模板，程序还有很多细节亟待改善。开源就是为了让大家能够基于这个程序改造出更多的花样，并丰富我们的开源社区，为更多开发者提供支持和便利。

### 源代码部署
1. 将原代码 fork 至您认为合适的本地位置
2. 使用 **Blend for Visual Studio 2019** 打开 Catch_Window_Tool.sln
3. 您可以直接清空 app.mainfest 这样就不会弹出UAC窗口，但这样可能会导致一些潜在的问题。
4. 在 Mainwindow.vb 中 Function Catch_window() 是抓取窗口的主要部分。
5. Function Catch_window() 是异步运行的，在 Async Sub Main() 中被调用。

### 问题反馈
反馈问题可以到:[我要反馈](https://github.com/SRInternet-Studio/Catch_Window_Tool/issues/new)issuse，你也可以通过我们的官方粉丝群 367798007 或 邮箱srinternet@qq.com （不建议使用邮箱）进行反馈。
PS:反馈问题时，请带上软件当时的截图，方便我们查看报错信息

### 支持我们 （纯属自愿）
1.  [爱发电](https://afdian.net/a/srinternet)
您的支持能让我们变的更好！！！！！！1

<div align="center">
<br>
<a href='https://www.srinternet.top/'><img src='https://avatars.githubusercontent.com/u/174720645?s=400&u=b01bdb1f44c319206aa43bbaaa5ed77dee2d54db&v=4' alt='en-ico' height="100" width="100"></img></a>
<h2>Made By 思锐工作室</h2>
<h2> - 遵循 GNU-GPL v3 开源协议 - </h2>
</div>

