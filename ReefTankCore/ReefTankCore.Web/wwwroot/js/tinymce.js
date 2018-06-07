tinymce.init({
    mode: "specific_textareas",
    editor_selector: "editor",
    plugins: 'link image code wordcount textcolor table media fullscreen help lists',
    toolbar: 'undo redo | fontselect forecolor backcolor | numlist bullist | link image media | code | fullscreen',
    branding: false,
    // enable title field in the Image dialog
    image_title: true,
    // enable automatic uploads of images represented by blob or data URIs
    automatic_uploads: true,
    // Target action for image upload.
    relative_urls: true,
});