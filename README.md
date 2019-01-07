# Theme800.QRCode 二维码插件

二维码插件用于在模板中通过标签将 URL 地址生成二维码图片并展示在页面中。

## 基本用法

二维码插件使用 stl:qrCode 标签生成二维码，二维码的地址为当前页面地址：

```
<stl:qrCode></stl:qrCode>
```

## 指定二维码地址

可以使用 url 属性指定二维码地址：

```
<stl:qrCode url="https://www.siteserver.cn"></stl:qrCode>
```

## 指定二维码图片尺寸

可以使用 size 属性指定二维码图片尺寸：

```
<stl:qrCode size="128"></stl:qrCode>
```

## 源代码

您可以在 [https://github.com/theme800/Theme800.RQCode](https://github.com/theme800/Theme800.RQCode) 中查看并获取二维码插件最新源代码。
