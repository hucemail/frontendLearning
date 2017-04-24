# Koala介绍
 koala 是一个编译less的小工具,当然编译less还可以采用node.js、Grunt等，本次我们采用Koala来对less进行编译。
 
 下载地址：[koala官网下载地址](http://koala-app.com/index-zh.html)
 
 下载安装完成后，打开界面如下图：
 ![](../images/1.png)
 
 可以点击设置按钮进行简体中文设置。
 
## koala编译
 
 编译就很简单了，只要把需要编译的less文件夹拖入到工具中即可执行编译，也可以鼠标右键进行编译和输出路径的设置
  ![](../images/2.png)

# 注释和变量

> 页面中使用还是得引用编译后的css，只是开发和维护用less 

注释：

 less中有两种注释，/**/和//，它们的区别在于第一种注释编译后会出现在真是的css项目中，第二种将不会执行编译

变量： 

 @test:300px;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//这样就定义了一个变量名为test的变量

使用变量： 

 width:@test;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; //设置宽度为300px


文件：main.less

    //定义测试宽度变量为200px
	@test_width:200px;
	body{
	  background-color: red;
	}
	/*设置宽度和高度为200px*/
	#box{
	  width:@test_width;
	  height: @test_width;
	  background-color: green;
	}

    
编译后：main.css
 
	body {
	  background-color: red;
	}
	/*设置宽度和高度为200px*/
	#box {
	  width: 200px;
	  height: 200px;
	  background-color: green;
	}
