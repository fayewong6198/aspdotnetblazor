window.getInnerHtml = (id) => {
    const data = document.getElementById(id).innerHTML;

    return data
}


window.createQuillEditor = (initValue, element, dotNetHelper) => {

    var toolbarOptions = [
        ['bold', 'italic', 'underline', 'strike'], // toggled buttons
        ['blockquote', 'code-block'],

        [{ 'header': 1 }, { 'header': 2 }], // custom button values
        [{ 'list': 'ordered' }, { 'list': 'bullet' }],


        [{ 'size': ['small', false, 'large', 'huge'] }], // custom dropdown
        [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
        ['link', 'image', ], // add's image support
        [{ 'color': [] }, { 'background': [] }], // dropdown with defaults from theme
        [{ 'font': [] }],
        [{ 'align': [] }],

        ['clean'] // remove formatting button
    ];

    var options = {
        debug: 'info',
        modules: {
            toolbar: toolbarOptions
        },
        placeholder: 'Compose an epic...',
        readOnly: false,
        theme: 'snow',

        bounds: "document.body",
    };

    var quill = new Quill(element, options);

    element.children[0].innerHTML = initValue;

    element.children[0].addEventListener("blur", function(e) {
        dotNetHelper.invokeMethodAsync('OnBlur', element.children[0].innerHTML);
    })
}