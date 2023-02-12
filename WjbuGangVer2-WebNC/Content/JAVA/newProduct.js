let previewContainer = document.querySelector('.new-product-preview');
let previewBox = previewContainer.querySelectorAll('.new-preview');

document.querySelectorAll('.new-product-container .new-product').forEach(product => {
    product.onclick = () => {
        previewContainer.style.display = 'flex';
        let name = product.getAttribute('data-name');
        previewBox.forEach(preview => {
            let target = preview.getAttribute('data-target');
            if (name == target) {
                preview.classList.add('active');
            }
        });
    };
});

previewBox.forEach(close => {
    close.querySelector('.fa-times').onclick = () => {
        close.classList.remove('active');
        previewContainer.style.display = 'none';
    };
});


var counter = 1;
setInterval(function () {
    document.getElementById ? ('radio' + counter).checked = true :
        counter++;
    if (counter > 4) {
        counter = 1;
    }
}, 5000);