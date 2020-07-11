export async function applyCommon() {
    this.loggedIn = !!localStorage.getItem('token');

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };
}