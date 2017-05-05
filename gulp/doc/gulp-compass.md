[参考文档](https://segmentfault.com/a/1190000004190261)

[compass官网](http://compass-style.org/reference/compass/)

# 环境搭建

在上篇中，编译sass文件采用的是gulp-sass，这是基于node环境编译的，所以不需要安装ruby。

都说sass是钉子，compass是锤子。这次采用gulp-compass来进行sass文件的编译，这将需要安装ruby环境，以及在ruby中安装compass，sass等

    gem install compass

具体如何安装使用，请查看sass章节相关的文档。

# gulp-compass

    npm install gulp-compass --save -dev

当然，插件的安装和gulp任务已打包  gulp.zip

和上节的gulp差不多，只是将 监听器和gulpfile中的 scss:build 换成了compass:build。

这样我们就能使用compass提供的各种 mixin 了，同时为了解决个浏览器的差异性，可以使用

    @import “compass/reset”

或者

	@import “normalize”  //需要安装normalize

