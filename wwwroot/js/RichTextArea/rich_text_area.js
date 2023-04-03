$('#text_input').trumbowyg({
    lang: 'ru',
    tagsToRemove: ['script', 'link'],
    autogrow: true,
    autogrowOnEnter: true,
    btns: [
        ['formatting'],
        ['strong', 'em', 'del'],
        ['superscript', 'subscript'],
        ['unorderedList', 'orderedList'],
        ['horizontalRule'],
        ['removeformat'],
        ['fullscreen']
    ]
});