## normalize介绍

normalize模块改良了reset模块，同一个各个版本浏览器的差异性，而不是对默认样式清零。

在项目中我们需要使用normalize模块来替换掉  `@import "compass/reset"` 

## 安装normalize

进入使用compass create创建的项目目录中执行

    gem install compass-normalize

安装成功后，你可以compass   gems目录中看到 compass-normalize的目录，我的位置在这

    C:\Ruby23\lib\ruby\gems\2.3.0\gems\compass-normalize-1.5

## 引入normalize

在config.rb文件头部增加

    require 'compass-normalize'

插件引入后即可在scss文件中使用

    @import "normalize"

来替换掉

    @import "compass/reset"

## 重复引入

在引入normalize之前我们看到还有一个插件

    require 'compass/import-once/activate'

这个是解决冲入引入插件的问题，比如：在scss文件中重复引入了两次或多次 normalize，但是在编译后的css中只有一次。

如果非要引入两次，可以这样

    @import "nomalize !"

使用 compressed编译，注释不会被编译进去，如果需要注释也参与编译，使用如下语法：

    /*!
	*
	*/