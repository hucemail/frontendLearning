## css3介绍

css3提供了很多样式属性，如：animation、box-shadow、border-radius等等。有些属性需要添加前缀才能支持不同浏览器的兼容性，如：

      -moz-box-shadow: 0px 0px 10px 5px green;
	  -webkit-box-shadow: 0px 0px 10px 5px green;
	  box-shadow: 0px 0px 10px 5px green;

如果这些前缀让开发者自己添加也就是麻烦点而已，但是像opacity这种，在IE中是不支持的  需要使用IE的hack来写。

恰好，对于兼容性之类的问题compass以提供mixin的方式帮我们解决了。

参考文档：[compass/css3](http://compass-style.org/reference/compass/css3/opacity/)

## 使用compass/css3模块

首先我们需要引入css3模块，当然直接引入compass之后，五大模块都引入了，除了layout和reset模块需要单独引用

    @import "compass"

也可以只引用css3

    @import "compass/css3"

前面已经提到过css3模块兼容性都是通过mixin的方式提供的，所以在书写scss样式时，都应当采用

    @include mixin

如下例子：

	@import "compass";
	#arc{
	  width: 100px;
	  height: 100px;
	  margin: 0 auto;
	  background-color: red;
	  @include  border-radius(100px);
	  @include box-shadow(0px 0px 10px 5px green);
	  @include opacity(0.3);
	}

生成：

    /* line 2, ../sass/index.scss */
	#arc {
	  width: 100px;
	  height: 100px;
	  margin: 0 auto;
	  background-color: red;
	  -moz-border-radius: 100px;
	  -webkit-border-radius: 100px;
	  border-radius: 100px;
	  -moz-box-shadow: 0px 0px 10px 5px green;
	  -webkit-box-shadow: 0px 0px 10px 5px green;
	  box-shadow: 0px 0px 10px 5px green;
	  filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=30);
	  opacity: 0.3;
	}


**filter是针对IE特有的hack**


## 其他模块

还有，诸如 Helper模块、utilities模块、typography模块都提供了很多的mixin，用到只是可以参考文档

文档地址：[compass文档](http://compass-style.org/reference/compass/)