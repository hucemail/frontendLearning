## 安装grunt-cli

> 上节成功安装了node，grunt是node框架中的一个命令行工具，安装grunt需要node的支持,即需要npm install

安装grunt也很简单：

    npm install -g grunt-cli

这条命令将会把grunt命令植入系统路径，这样就能在任意目录运行他，原因是

每次运行grunt时，它都会使用node的require查找本地是否安装grunt，如果找到CLI便加载这个本地grunt库
然后应用我们项目中的GruntFile配置，并执行任务

>安装 grunt-cli 并不等于安装了 Grunt 任务运行器！Grunt CLI 的任务是运行 Gruntfile 指定的 Grunt 版本。 这样就可以在一台电脑上同时安装多个版本的 Grunt。还是没读懂到底grunt-cli和grunt啥区别，那么你先使用吧，使用后你可以就明白了。

## 检测grunt

    grunt -v

输出信息：

    grunt-cli: The grunt command line interface (v1.2.0)

	Fatal error: Unable to find local grunt.
	
	If you're seeing this message, grunt hasn't been installed locally to
	your project. For more information about installing and configuring grunt,
	please see the Getting Started guide:
	
	http://gruntjs.com/getting-started

说明grunt已经安装成功了。

那么具体安装在什么位置了呢，并没有在nodejs目录中，我们通过查找环境变量path，可以看到grunt的路径

    C:\Users\Administrator\.dnx\bin;C:\Users\Administrator\AppData\Roaming\npm

可以在我的电脑中看到，确实npm下面已经存在了grunt，修改时间就是我们刚安装的时间。

