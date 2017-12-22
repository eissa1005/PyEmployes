function ConfirmDelete() {
     if(!confirm('Are you sure you want to delete?!')) return false;
}
function imgError(image) {
    image.onerror = "";
    image.src = "/images/notfound.png";
    return true;
}
