/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = 'zh-tw';
    //config.uiColor = '#99CCFF';

    config.extraPlugins = 'autogrow';
    config.autoGrow_minHeight = 200;
    config.autoGrow_maxHeight = 600;
    config.autoGrow_bottomSpace = 50;

    //config.resize_enabled = false;

    config.htmlEncodeOutput = true;

    config.allowedContent = true;

    config.pasteFilter = null;

    config.font_names = 'Arial;Arial Black;Comic Sans MS;Courier New;Tahoma;Times New Roman;Verdana';

    config.fontSize_siezs = '24/24px;36/36px;48/48px';

    config.toolbar_Custom = [
        { name: 'document', items: ['Source'] },
        { name: 'clipboard', items: ['Cut', 'Copy', 'Paste'] },
        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript'] },
        { name: 'undo', items: ['Undo', 'Redo'] },
        { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
        '/',
        { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
        { name: 'colors', items: ['TextColor', 'BGColor', 'Image'] }
    ];
};
//CKEDITOR.on('instanceReady', function (ev) {
//    with (ev.editor.dataProcessor.writer) {
//        setRules("p", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("h1", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("h2", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("h3", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("h4", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("h5", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("div", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("table", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("tr", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("td", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("iframe", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("li", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("ul", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//        setRules("ol", { indent: false, breakBeforeOpen: false, breakAfterOpen: false, breakBeforeClose: false, breakAfterClose: false });
//    }
//})

