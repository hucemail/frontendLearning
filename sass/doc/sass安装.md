# 准备安装包

ruby 下载：[http://rubyinstaller.org/downloads](http://rubyinstaller.org/downloads "Runby下载地址")，[本地地址](../util/rubyinstaller-2.3.3.exe)

sass 下载：[https://rubygems.org/gems/sass](https://rubygems.org/gems/sass "sass下载地址"),[本地地址](../util/sass-3.4.23.gem)


# 安装ruby
> sass是基于ruby语言开发的，需要依赖ruby环境。

这里需要注意，必须安装在C盘，以防止不必要的错误，安装时勾选添加环境变量，如图


![](http://img.mukewang.com/54f561190001531806350474.jpg)

安装完成后输入如下命令即可检测是否安装成功

    ruby -v

# 安装sass

打开 ruby 命令行：

![](http://img.mukewang.com/54f5615f00011cb604530648.jpg)

执行

    gem install <把下载的安装包拖到这里>

# 测试安装

    sass -v

# 卸载sass

    gem uninstall sass


# 安装compass

    gem install <把下载的安装包拖到这里>

# 测试安装

    compass -v

# 创建compass项目

    compass create 项目目录