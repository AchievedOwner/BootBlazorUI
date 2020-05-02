# BootBlazorUI
BootBlazorUI 是基于 Bootstrap 4.x 版本并构建于 ASP.NET CORE 3.1 的 UI 库，不依赖于 JQuery 和 Bootstrap.js 实现所有交互，可应用于 Mvc / Razor Page / Blazor 等 Web 应用程序。BootBlazorUI 更偏向于交互和实用性，而不仅仅是静态的组件。

BootBlazorUI 更偏向于交互性和实用性，而不仅仅是静态的组件。
# 支持环境
* .NET CORE 3.1+ SDK
* .NET Standard 2.0+

# 最新版本（v1.0-preview1）
> Install-Package BootBlazorUI

# 快速上手
* 引入内置的 bootstrap 样式 `<link href=_content/BootBlazorUI/bootstrap.min.css" rel="stylesheet/>` ，或你也可以自己引入 bootstrap 的样式；
* 引入组件样式：`<link href="_content/BootBlazorUI/components.css" rel="stylesheet" />`
* 使用 `@using BootBlazorUI` 引入命名空间，你可以在 `_Import.cshtml`(Mvc/Razor Page) | `_Import.razor`(Blazor) 中引入全局命名空间，或在某个页面中引入命名空间；



# Demo 演示
### [在线文档](http://101.133.155.72/)

## 按钮（Buttons）
![按钮](img/demo-button.png)
```html
<Button Color="Color.Primary">Primary</Button>
<Button Color="Color.Secondary">Secondary</Button>
<Button Color="Color.Info">Info</Button>
<Button Color="Color.Warning">Warning</Button>
<Button Color="Color.Success">Success</Button>
<Button Color="Color.Danger">Danger</Button>
<Button Color="Color.Light">Light</Button>
<Button Color="Color.Dark">Dark</Button>
```
## 进度条（Progress Bar）
![进度条](img/demo-progress-bar.png)
```html
<ProgressBar Value="80" Color="Color.Primary" />
<ProgressBar Value="65" Color="Color.Secondary" />
<ProgressBar Value="30" Color="Color.Info" />
<ProgressBar Value="77" Color="Color.Warning" />
<ProgressBar Value="100" Color="Color.Success" />
<ProgressBar Value="40" Color="Color.Danger" />
<ProgressBar Value="92" Color="Color.Light" />
<ProgressBar Value="50" Color="Color.Dark" />
```

## 对话框
![对话框](img/demo-modal.png)
```html
<Button OnClick="@(() => modal.Open())"/>
弹出模态框
</Button>

<Modal @ref="modal">
    <HeaderTemplate>
        对话框标题
    </HeaderTemplate>
    <BodyTemplate>
        显示了一个对话框的内容
    </BodyTemplate>
</Modal>

@code{
Modal modal = new Modal();
}
```

## 徽章
![徽章](img/demo-badge.png)
```html
<Badge Color="Color.Primary">Primary</Badge>
<Badge Color="Color.Secondary">Secondary</Badge>
<Badge Color="Color.Info">Info</Badge>
<Badge Color="Color.Success">Success</Badge>
<Badge Color="Color.Warning">Warning</Badge>
<Badge Color="Color.Danger">Danger</Badge>
<Badge Color="Color.Light">Light</Badge>
<Badge Color="Color.Dark">Dark</Badge>
```
## 数据表格
![Demo Datagrid](img/demo-datagrid.png)
```html
<BootDataGrid DataBind="page => LoadData(page,25)" FixHeader="true" RowFixHeight="300" TotalRecordCount="totalCount" ShowPagination="true" PageSize="25">
    <BootDataGridColumn Title="Id" Field="Id" />
    <BootDataGridColumn Title="姓名" Field="Name" />
    <BootDataGridColumn Title="生日" Field="Birthday" />
</BootDataGrid>
```