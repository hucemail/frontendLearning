[参考文档](http://www.cnblogs.com/lpdong/p/6211657.html)

#简介

gulp是流式的前端自动化框架，它提供了众多插件：js压缩，css压缩，sass编译压缩，图片压缩，浏览器自动刷新等等。。

通过配置gulp，编写各类gulp任务可以完全实现自动化功能，一次配置后，上线发布只需要执行一条命令就可以完成对所以相应文件的编译压缩打包操作。

虽然最初搭建gulp编写各种任务麻烦点，但是编写好起手架后，以后众多项目可以直接拿过来使用。很是方便。

# 环境安装
> gulp是基于nodejs的，需要安装nodejs,nodejs的安装在grunt章节以解释,安装也很简单，上官网下载nodejs安装包傻瓜式安装就行了，检测安装使用 node -v

安装gulp：

    npm install gulp -g

和grunt一样，首先需要安装全局的gulp。安装完成后实际路径还是

    C:\Users\Administrator\AppData\Roaming\npm

检测gulp：

    gulp -v

# 目录结构

	    ├─ 项目名称根目录
        ├─ gulp/                  # gulp配置目录
            ├─ tasks              # 任务配置目录
                ├─ clean.js       # 清理配置——清理发布文件夹
                ├─ css.js         # 样式配置——压缩处理样式表
                ├─ html.js        # 页面配置——可压缩处理页面文件
                ├─ image.js       # 图片配置——可对图片文件压缩
                ├─ plugins.js     # 插件配置——仅移动第三方插件
                ├─ resources.js   # 资源配置——仅移动资源文件,如excel,mp3,avi等
                ├─ scripts.js     # 脚本配置——提供对脚本文件的压缩
                ├─ scss.js        # sass配置——对sass语法进行编译
                ├─ service.js     # 服务配置——开启浏览器
                └─ watch.js       # 监听配置——提供了众多监听功能,浏览器自动刷新就是在此进行监听
            └─ config             # gulp配置文件
        ├─ src/                   # 源代码目录
            ├─ */                 # 任意目录都可存放html
            ├─ bundles/           # 捆绑资源的目录
                ├─ css/           # 存放传统样式表的目录
                ├─ images/        # 存放图片文件的目录
                ├─ js/            # 存放脚本文件的目录
                ├─ plugins/       # 存放第三方插件的目录
                ├─ resources/     # 存放视频文档等资源的目录
                └─ scss/          # 存放sass样式的目录
        ├─ gulpfile.js            # gulp入口配置文件
        └─ package.json           # npm包管理文件 


# 如何运行

在使用gulp时，都必须要存在并正确的配置两个文件

    package.json
	gulpfile.js

整个起手架已经搭建好了，只需要解压gulp.zip，在根目录输入如下命令可运行

    gulp   //默认出现命令的帮助文档
	
	gulp serve  //运行，会打开浏览器窗口，没打开也没关系，手动在浏览器输入，http://localhost:2017

既然知道如何跑起来了，那么接下来该介绍gulp的配置了、

# 详解package.json

插件需要在项目根目录进行安装，常用的各个插件列表如下，按需安装
	
	npm install gulp --save -dev

    npm install gulp-uglify --save -dev          //js压缩插件

	npm install gulp-concat --save -dev          //js合并插件
	
	npm install gulp-cssnano --save -dev         //css压缩插件
	
	npm install gulp-less --save -dev            //less文件编译 

	npm install gulp-sass --save -dev            //sass文件编译 
	
	npm install gulp-imagemin --save -dev        //图片压缩插件
	
	npm install gulp-htmlmin --save -dev         //html压缩插件
	
	npm install del --save -dev                  //文件删除模块

	npm install browser-sync  --save -dev        //自动刷新插件


这是我package.json的安装清单：

npm：

    {
	  "name": "gulp",
	  "version": "0.0.1",
	  "dependencies": {
	    "browser-sync": "^2.18.8",
	    "browsersync-ssi": "^0.2.4",
	    "del": "^2.2.2",
	    "fs": "0.0.1-security",
	    "gulp": "^3.9.1",
	    "gulp-concat": "^2.6.1",
	    "gulp-cssnano": "^2.1.2",
	    "gulp-htmlmin": "^3.0.0",
	    "gulp-imagemin": "^3.2.0",
	    "gulp-load-plugins": "^1.5.0",
	    "gulp-sass": "^3.1.0",
	    "gulp-uglify": "^2.1.2",
	    "gulp-zip": "^4.0.0",
	    "path": "^0.12.7",
	    "require-dir": "^0.3.1",
	    "run-sequence": "^1.2.2"
	  }
	}

cnpm:

    {
	  "name": "gulp",
	  "version": "0.0.1",
	  "devDependencies": {
	    "browser-sync": "^2.18.8",
	    "browsersync-ssi": "^0.2.4",
	    "del": "^2.2.2",
	    "fs": "0.0.1-security",
	    "gulp": "^3.9.1",
	    "gulp-concat": "^2.6.1",
	    "gulp-cssnano": "^2.1.2",
	    "gulp-htmlmin": "^3.0.0",
	    "gulp-imagemin": "^3.2.0",
	    "gulp-load-plugins": "^1.5.0",
	    "gulp-sass": "^3.1.0",
	    "gulp-uglify": "^2.1.2",
	    "gulp-zip": "^4.0.0",
	    "path": "^0.12.7",
	    "require-dir": "^0.3.1",
	    "run-sequence": "^1.2.2"
	  }
	}




**小技巧一**
> 当安装gulp出错时，可以使用   npm install -g cnpm
> 
> 然后再用   cnpm  install gulp --save-dev
> 
> 主要造成的原因是因为国内防火墙的问题，切换到cnpm就好了

**小技巧二**
> 如果你嫌一个个插件安装太麻烦，可以先行配置package.json,配置好之后执行npm install一起安装
> 
> 当然，npm很慢，你也可以使用cnpm install安装

**小技巧三**
> 插件和整个框架已经打包压缩在gulp.zip文件中，直接下载解压即可，无需在安装packjson中的插件了。
> 
> 当然，最基本的node环境以及全局gulp还是要安装的

# 详解gulp任务配置



插件安装完成后，还需要配置各项task才能发挥gulp的强大功能，

如果不知道某项插件如何使用可以上[https://www.npmjs.com/](https://www.npmjs.com/)进行查找相应的插件，都有使用说明的

从目录结构中得知，我们所有的任务都在gulp文件夹下，对照目录结构首先配置config.js:

## 第一步：配置config.js

	module.exports = function () {
	    var confilg = {
	        src: "src/",                        //源代码目录
	        tasks: "./gulp/tasks/",              //任务目录
	        port: 2017,                        //端口号
	        build: "build/",                   //编译目录
	        release: "release/",                //发布目录
	        paths:{
	            htmls:['src/**/*.html',"!src/bundles/**/*.html"],      //监听src下所有html文件，排除src/bundles目录下的html
	            desthtmls:"build/",                                  //当监听到src下的html文件有变动后，会经过相应的任务处理后自动更新到build目录
	            buildhtmls:'build/**/*.html',                         //build目录下的html文件有改变会自动刷新浏览器
	            images:"src/bundles/images/**/*.{jpg,png,jpeg,gif,ico}",//监听src/bundles/images下的图片文件
	            destimages:"build/bundles/images",                    //监听到图片文件有变动，会进行相应的任务处理自动更新到build/bundles/images目录
	            js:"src/bundles/js/**/*.js",
	            destjs:"build/bundles/js",
	            css:"src/bundles/css/**/*.css",
	            destcss:"build/bundles/css",
	            scss:"src/bundles/scss/**/*.scss",
	            destscss:"build/bundles/css",
	            plugins:"src/bundles/plugins/**/*.*",
	            destplugins:"build/bundles/plugins",
	            resources:"src/bundles/resources/**/*.*",
	            destresources:"build/bundles/resources",
	        }
	    };
	    return confilg;
	};


大致流程也就是，监听相应的源代码文件夹中文件的变动，当有变动之后会进行相应的任务处理，处理完成后自动更新到编译后的目录中。

## 第二步:配置监听器 watch.js

    module.exports = function (gulp, plugins, config, browserSync, runSequence) {
	    gulp.task("watch", function () {
	        //启动一组任务
	        gulp.start('html:build',"image:build","js:build","css:build","scss:build","plugins:build","resources:build");
	
	        gulp.watch(config.paths.htmls,['html:build']);  //监听html，并将其交给名为html:build的任务进行处理
	
	        gulp.watch(config.paths.images,['image:build']);
	
	        gulp.watch(config.paths.js,['js:build']);
	
	        gulp.watch(config.paths.css,['css:build']);
	
	        gulp.watch(config.paths.scss,['scss:build']);
	
	        gulp.watch(config.paths.plugins,['plugins:build']);
	
	        gulp.watch(config.paths.plugins,['resources:build']);
	
	        //dist目录下的任何html发生改变时(包括子目录)自动刷新
	        gulp.watch(config.paths.buildhtmls).on("change", browserSync.reload);
	    });
	};

从代码的注释中也很容易理解如何载入监听器。每当写一个task之后，如果想要实时同步更新展示，都需要配置监听器。

知道了监听html有变动之后，html:build会处理，那么这个任务又是如何实现处理压缩的呢？

## 第三步：细分任务之html.js

    module.exports=function (gulp,plugins,config,browserSync,runSequence) {
	    gulp.task("html:build",function () {
	        return gulp.src(config.paths.htmls)
	            .pipe(plugins.htmlmin({
	               // collapseWhitespace: true,            //压缩html
	                //collapseBooleanAttributes: true,     //省略布尔属性的值
	                removeComments: true,                //清除html注释
	               // removeEmptyAttributes: true,         //删除所有空格作为属性值
	                removeScriptTypeAttributes: true,    //删除type=text/javascript
	                removeStyleLinkTypeAttributes: true, //删除type=text/css
	                minifyJS:true,                       //压缩页面js
	                minifyCSS:true                       //压缩页面css
	            }))
	            .pipe(gulp.dest(config.paths.desthtmls))
	            .pipe(browserSync.stream());
	    });
	};

所有任务基本长一个样，都是gulp.task语法规则。

如果这个看不懂没关系，来看个比较常用的。都知道发布上线为了解决带宽和访问速度问题，要对js等资源文件进行压缩到最小体积。

## 第四步：细分任务之scripts.js


    module.exports = function (gulp, plugins, config, browserSync, runSequence) {
	    gulp.task("js:build", function () {
	        return gulp.src(config.paths.js)
	            .pipe(plugins.uglify({
	                mangle: true,  //类型：Boolean 默认：true 是否修改变量名
	                compress: true //类型：Boolean 默认：true 是否完全压缩
	            }))
	            .pipe(gulp.dest(config.paths.destjs))
	            .pipe(browserSync.stream());
	    });
	};

首先通过task定义了名为js:build的任务，gulp任务是流式执行的，具体执行如下：

* 通过uglify插件进行压缩
* 通过dest将压缩后的文件房子在destjs配置的目录中
* 写入browserSync流管道

就这么三步解决了js压缩的问题，相比以前发布上线要一个一个js通过压缩工具压缩简直方便太多了。


## 第五步：入口配置之gulpfile.js

该配置的也配置了，该开发的task也开发好了，监控也添加了，总得有个入口来加载这些任务和监听器吧？这就是最关键的入口gulpfile.js

    var gulp = require('gulp');

	//配置文件
	var config = require("./gulp/config")();
	
	// 自动刷新浏览器工具
	var browserSync = require('browser-sync').create();
	
	//顺序执行任务插件
	var runSequence = require('run-sequence');
	
	// 加载插件
	var plugins = require("gulp-load-plugins")();
	
	//获得所有任务列表，如：gulp/tasks/clean.js
	var tasks = require("fs").readdirSync(config.tasks);
	
	//加载任务
	tasks.forEach(function (task) {
	    require(config.tasks + task)(gulp, plugins, config, browserSync, runSequence);
	});
	
	//默认任务
	gulp.task("default",["helper"]);
	
	//帮助说明
	gulp.task("helper", function () {
	    console.log('*************************************************************');
	    console.log('*                                                          *');
	    console.log('*   gulp helper       帮助说明                             *');
	    console.log('*   gulp serve        启动开发监控(将启动浏览器自动刷新)   *');
	    console.log('*   gulp build        编译(不会启动浏览器刷新)             *');
	    console.log('*   gulp publish      打包（需要先执行编译才能进行打包）   *');
	    console.log('*   gulp release      发布（编译打包一体操作）             *');
	    console.log('*************************************************************');
	});
	
	//启动任务
	gulp.task("serve", function () {
	    runSequence("clean:build", "reload", "watch");
	});
	//编译
	gulp.task("build", function () {
	    runSequence("clean:build", 'html:build', "image:build", "js:build", "css:build", "scss:build","plugins:build","resources:build");
	});
	//打包
	gulp.task("publish", function () {
	    return gulp.src(config.build + "**/*")
	        .pipe(plugins.zip('publish.zip'))
	        .pipe(gulp.dest(config.release));
	});
	//发布
	gulp.task("release",function () {
	    runSequence("clean:build", 'html:build', "image:build", "js:build", "css:build", "scss:build","plugins:build","resources:build","publish");
	});


文件中介绍了，如何加载配置文件，加载任务列表，加载插件，还有默认任务，启动的任务，编译打包发布等任务的实现。