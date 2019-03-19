# 这是一个后台Demo[（前端Demo传送门）](https://github.com/Maple512/abp-angular)

> 编码环境

1. Net Core Version:2.2
2. 编码工具：Visual Studio 2017
3. 数据库：SQL Server 2008

> 技术栈 & 参考文档

1. [Abp官网](https://aspnetboilerplate.com)（[英文文档](https://aspnetboilerplate.com/Pages/Documents)）
2. [52Abp官网](https://www.52abp.com)（[文档](https://www.52abp.com/Wiki)，[预览](https://pro.52abp.com/)）
3. ...

> 功能列表

| 功能     | 单元测试 | 完成度 | 更新日期 |
| -------- | -------- | ------ | -------- |
| 审计日志 | ×        | √      |          |
| 租户     | ×        | ×      |          |
| 角色     | ×        | ×      |          |
| 用户     | ×        | ×      |          |
| 组织机构 | ×        | ×      |          |
| 系统设置 | ×        | ×      |          |
| 书架     | ×        | ×      |          |
| 图书     | ×        | ×      |          |

> 如何使用？

1. 打开本地项目文件
2. 找到src\AbpLearning.Web.Host\appsettings.json，检查数据库连接字符串
3. 打开程序包控制台程序，默认项目为src\AbpLearning.EntityFrameworkCore.
4. 键入命令：Update-Migrator，等待数据库迁移完成
5. 右键Web.Host项目，设置为启动项目
6. CTRL+F5运行项目

> PS:本项目使用[52Abp](https://www.52abp.com)框架搭建
