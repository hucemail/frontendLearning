> 本节介绍了如何定义和使用方法(mixin)，如何实现样式继承关系,以及如何压缩css。


# mixin

定义mixin语法,需要使用@mixin标识，如：

    @mixin a($color:red,$fontsize:12px) {
	  color: $color;
	  text-decoration: none;
	  font-size: $fontsize;
	}

使用mixin需要使用@include(也可以使用多个mixin)如：

    a {
	  @include a(green);
	  &:hover {
	    color: red;
	  }
	}

如上代码生成最终css：

    /* line 13, ../sass/screen.scss */
	a {
	  color: green;
	  text-decoration: none;
	  font-size: 12px;
	}
	/* line 15, ../sass/screen.scss */
	a:hover {
	  color: red;
	}

# 继承

如下代码演示了，serious-error继承了error和border-error,使用百分号标识的只能被继承，不会被编译输出：

    //错误消息字体颜色
	.error {
	  color: red;
	}
	
	//错误消息边框
	%error-border {
	  border: solid 1px red;
	}
	
	.serious-error {
	  @extend .error,%error-border;
	  font-weight: bold;
	}

编译完成后：

    /* line 8, ../sass/screen.scss */
	.error, .serious-error {
	  color: red;
	}
	
	/* line 13, ../sass/screen.scss */
	.serious-error {
	  border: solid 1px red;
	}
	
	/* line 17, ../sass/screen.scss */
	.serious-error {
	  font-weight: bold;
	}

# 压缩CSS

修改config.rb

    # You can select your preferred output style here (can be overridden via the command line):
	# output_style = :expanded or :nested or :compact or :compressed
	output_style=:compressed