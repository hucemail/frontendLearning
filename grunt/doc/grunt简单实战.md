## 创建Grunt项目

创建一个文件夹就行，我建立了一个learn的文件夹，以表标准的grunt项目中根文件夹(learn)中必须包含两个文件

- package.json:用于保存项目元数据
- Gruntfile.js：用于配置和定义任务、加载Grunt插件

首先我们建立一个文件package.json

    {
	  "name": "learn",
	  "version": "0.0.1"
	}

和Gruntfile.js

    // 包装函数
	module.exports = function(grunt) {
	    // 任务配置,所有插件的配置信息
	    grunt.initConfig({
	        pkg: grunt.file.readJSON('package.json'),
	    });
	};

## 安装插件

进入learn目录执行

    npm install grunt-contrib-grunt --save-dev
	npm install grunt-contrib-uglify --save-dev
	npm install grunt-contrib-watch --save-dev

- grunt:安装最新版的grunt，前面安装的grunt-cli并不等于Grunt运行器
- uglify：js，css等压缩插件
- watch：自动监听插件

插件安装完成后，package.json会改变，项目目录总也会多出来node_modules文件夹

## 配置Gruntfile.js

如配置uglify插件：

    // 包装函数
	module.exports = function(grunt) {
	
	  // 任务配置,所有插件的配置信息
	  grunt.initConfig({
	    pkg: grunt.file.readJSON('package.json'),
	    
	    // uglify插件的配置信息
	    uglify: {
	      build: {
	        src: 'scripts/a.js',
	        dest: 'build/scripts/a.min.js'
	      }
	    }
	  });
	
	  // 告诉grunt我们将使用插件
	  grunt.loadNpmTasks('grunt-contrib-uglify');
	
	  // 告诉grunt当我们在终端中输入grunt时需要做些什么
	  grunt.registerTask('default', ['uglify']);
	
	};

然后我们在learn文件夹中新建一个scripts文件夹，和a.js文件，里面随便写点啥，
在执行 grunt，我们会看到多出来build/scripts/a.min.js

a.js已经得到了压缩版，但是这样手动运行grunt太麻烦，我们把watch配置进去，以后每次修改a.js都会自动帮我们压缩，如果想压缩scripts下所有的js，也只是改Gruntfile.js的配置就行

    /**
	 * Created by Administrator on 28/4/2017.
	 */
	// 包装函数
	module.exports = function(grunt) {
	
	    // 任务配置,所有插件的配置信息
	    grunt.initConfig({
	        pkg: grunt.file.readJSON('package.json'),
	
	        // uglify插件的配置信息
	        uglify: {
	            build: {
	                src: 'scripts/test.js',
	                dest: 'build/scripts/test.min.js'
	            }
	        },
	        //imagemin插件的配置信息
	        imagemin:{
	            dynamic:{
	                files:[{
	                    expand:true,
	                    cwd:"images",
	                    src:["**/*.{png,jpg,gif}"],
	                    dest:"build/images/"
	                }]
	            }
	        },
	        // watch插件的配置信息
	        watch: {
	            scripts: {
	                files: ['scripts/*.js'],
	                asks: ['uglify'],
	                options: { spawn: false}
	            },
	            images: {
	                files: ['images/**/*.{png,jpg,gif}'],
	                tasks: ['imagemin'],
	                options: {
	                    spawn: false
	                }
	            }
	        }
	    });
	
	    // 告诉grunt我们将使用插件
	    grunt.loadNpmTasks('grunt-contrib-uglify');
	    grunt.loadNpmTasks('grunt-contrib-imagemin');
	    grunt.loadNpmTasks('grunt-contrib-watch');
	
	    // 告诉grunt当我们在终端中输入grunt时需要做些什么
	    grunt.registerTask('default', ['uglify',"imagemin","watch"]);
	
	};
