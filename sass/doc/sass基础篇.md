# sass介绍

> 本节介绍了如何定义变量，@import，以及嵌套的语法

sass有两种语法：

一种是ruby的写法 (对空格敏感，没有大括号，都是以空格来进行缩进)，后缀是 .sass

另外一种是同css一样的写法，后缀是 .scss


以 _ (下划线)开头的 scss文件将不会被编译成独立的css文件，它一般用于 @import 包含在其他scss文件中。

# sass准备工作

在介绍sass语法之前我们需要做下准备工作

### 利用compass创建sass项目

    compass create  项目名称

目录结构：
	
	sass  存储scss文件
	stylesheets  存储编译后的css
	config.rb  配置文件

我们可以从config.rb文件中看到

    http_path = "/"
	css_dir = "stylesheets"
	sass_dir = "sass"
	images_dir = "images"
	javascripts_dir = "javascripts"

一目了然	

### 如何开启实时编译

进入项目目录后执行：

    compass watch

### 修改编码

sass安装后默认是GBK编码，如果scss文件中包含中文，就算是中文注释，都会导致编译成css失败，所以需要修改如下文件

C:\Ruby23\lib\ruby\gems\2.3.0\gems\sass-3.4.23\lib\sass\engine.rb


在require语句结束处，如：

    require 'sass/media'
	require 'sass/supports'
	module Sass   
	Encoding.default_external = Encoding.find('utf-8')

或者在scss文件头部新增：

    @charset "utf-8"


# @import

通常我们把变量都放在一个 _variables.scss 文件中，其他文件要使用变量，只需要使用@import引入 _variables.scss 文件就行了。

以下划线开头的scss文件有几个特点：

1. 不会被独立编译，只能用于其它文件的引入
2. 假设有 _variables.scss 文件，如果在创建  variables.scss 就会编译出错，在sass编译中这相当于一个文件
3. 使用import时，可以省略下划线和后缀名，它会自己去寻找进行匹配

如：

    @import "variables","compass/reset";

首先我们创建  _variables.scss  然后在screen.scss中使用import引入

# 变量、嵌套、属性嵌套语法

> scss中有两种注释，//和/**/   后者会被编译到css

    $headline-ff:Braggadocio,Arial,"微软雅黑";
	$main-sec-ff:Arial,"微软雅黑";

这样就定义了两个字体的变量。

编译前screen.scss

    @import "variables","compass/reset";
	.headline{
	  font-family: $headline-ff;
	}
	.main-sec{
	  font-family: $main-sec-ff;
	  .detail{
	    font-size: 12px;
	  }
	  .headline{
	    font:{
	      family: $main-sec-ff;
	      size: 16px;
	    }
	  }
	}

编译后screen.css

    /* line 7, ../sass/screen.scss */
	.headline {
	  font-family: Braggadocio, Arial, "微软雅黑";
	}
	
	/* line 10, ../sass/screen.scss */
	.main-sec {
	  font-family: Arial, "微软雅黑";
	}
	/* line 12, ../sass/screen.scss */
	.main-sec .detail {
	  font-size: 12px;
	}
	/* line 15, ../sass/screen.scss */
	.main-sec .headline {
	  font-family: Arial, "微软雅黑";
	  font-size: 16px;
	}


