import { Menu } from '@yoyo/theme';

// 全局的左侧导航菜单
export class AppMenus {
  // new
  static Menus: Menu[] = [
    {
      text: '', // 无本地化显示字符
      i18n: 'HomePage', // 本地化主键(ABP本地化)
      acl: '', // 权限
      icon: { type: 'icon', value: 'home' }, // 图标
      link: '/app/home', // url 地址
      // hide: true,  // 强制隐藏
      // ...还有更多选项，请查看 Menu成员
    },
    {
      text: '权限管理',
      i18n: 'PermissionManagement',
      acl: 'Administrator',
      icon: { type: 'icon', value: 'setting' },
      children: [
        {
          text: '',
          i18n: 'Tenants',
          acl: 'Pages.Tenants',
          icon: { type: 'icon', value: 'team' },
          link: '/app/tenants',
        },
        {
          text: '',
          i18n: 'Roles',
          acl: 'Pages.Roles',
          icon: { type: 'icon', value: 'safety' },
          link: '/app/roles',
        },
        {
          text: '',
          i18n: 'Users',
          acl: 'Pages.Users',
          icon: { type: 'icon', value: 'user' },
          link: '/app/users',
        },
      ],
    },
    {
      text: '',
      i18n: 'About',
      icon: { type: 'icon', value: 'info-circle' },
      link: '/app/about',
    },
  ];
}
