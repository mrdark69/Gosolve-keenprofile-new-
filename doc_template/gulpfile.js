//... For Gulp ruby Sass
// โหลด package "gulp" มาใช้ (บรรทัดนี้ต้องใส่เสมอ)
var gulp = require('gulp');

// โหลด package "gulp-ruby-sass" มาใช้ (บรรทัดนี้ต้องใส่เวลาติดตั้ง plugin เสริม)
var sass = require('gulp-ruby-sass');
var sourcemaps = require('gulp-sourcemaps');


var src = {
    sass: 'dev/scss/',
    scss: 'dev/scss/**/*.scss'
}

gulp.task('sass', function() {
    return sass(src.sass, { compass: true })
        .on('error', function(err) {
            console.log(err.message);
        })
        .pipe(gulp.dest('dev/css')) // เก็บไฟล์ css ไว้ที่โฟลเดอร์ css
});

//gulp.task('sass', function () {
//    // ให้คอมไพล์ .scss ทุกไฟล์ที่อยู่ในโฟลเดอร์ scss
//    return gulp.src(['dev/scss/**/*.scss'])
//        .pipe(sass({
//            compass: true, // ใช้ Compass
//            style: 'nested' // เลือก output แบบ compressed
////            sourcemap: true,
////            sourcemapPath: '../scss'
//        }))
//        .on('error', function (err) {
//            console.log(err.message);
//        })
//        .pipe(gulp.dest('dev/css')) // เก็บไฟล์ css ไว้ที่โฟลเดอร์ css
//
//
//
//});





var rename = require("gulp-rename");
var minifyCSS = require('gulp-minify-css');

gulp.task('minify-css', function() {

    gulp.src('./dev/css/**/*.css')
        .pipe(rename({
            suffix: ".min",
            extname: ".css"
        }))
        .pipe(minifyCSS({ keepBreaks: false }))
        .pipe(gulp.dest('./assets/css/'))
});



var coffee = require('gulp-coffee');
var gutil = require('gulp-util');

gulp.task('coffee', function() {
    gulp.src('./dev/coffee/*.coffee')
        .pipe(coffee({ bare: true }).on('error', gutil.log))
        .pipe(gulp.dest('./dev/js/'))
});




var uglify = require('gulp-uglify');

gulp.task('minify-js', function() {
    gulp.src('./dev/js/**/*.js')
        .pipe(rename({
            suffix: ".min",
            extname: ".js"
        }))
        .pipe(uglify())
        .pipe(gulp.dest('./assets/js/'))
});


// โหลด package "browser-sync" มาใช้ (บรรทัดนี้ต้องใส่เวลาติดตั้ง plugin เสริม)
var browserSync = require('browser-sync');

// สร้าง task ชื่อว่า "browser-sync" ขึ้นมา พร้อมกับระบุงานที่จะให้ task นี้ทำ
gulp.task('browser-sync', function() {
    browserSync({
        server: {
            baseDir: "./"
        }
    });
});


//,'minify-css','coffee','minify-js'
// 'sass','minify-css','coffee','minify-js',
gulp.task('default', ['browser-sync'], function() {
    // ระบุว่า default task ทำอะไร (เว้นไว้ก่อน)
    gulp.watch(['*.html'], browserSync.reload);
    gulp.watch(['**/*.html'], browserSync.reload);
    gulp.watch(['**/css/**/*.css'], browserSync.reload);
    gulp.watch(['**/*/js/**/*.js'], browserSync.reload);
    // เมื่อไฟล์ scss มีการเปลี่ยนแปลง ก็จะสั่งให้ task "sass" ทำงาน
    // gulp.watch(src.scss, ['sass']);
    // gulp.watch("dev/css/**/*.css", ['minify-css']);
    // gulp.watch("dev/coffee/**/*.coffee", ['coffee']);
    // gulp.watch("dev/js/**/*.js", ['minify-js']);


});