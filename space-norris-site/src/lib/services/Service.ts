import Store from './Store'

export default class Service {

    private static readonly fetch = window.fetch?.bind(window);
    private static readonly url = Store.getByName('devUrl');
    private static readonly baseNorrisUrl = "https://api.chucknorris.io";

    public static async GetChuckNorrisCategories() {
        try {
            const response = await this.fetch(`${this.url}/chuck/categories`);

            //TODO Need ot handle failed response

            return await response.json();
        } catch (err) {
            console.error('Command Error', err);
            //TODO Show error page
        }
    }

    public static async GetChuckNorrisJokesByCategory(category: string) {
        try {
            const response = await this.fetch(`${this.baseNorrisUrl}/jokes/random?category=${category}`);

            //TODO Need ot handle failed response

            return await response.json();
        } catch (err) {
            console.error('Command Error', err);
            //TODO Show error page
        }
    }

    public static async GetStartWarsPeople() {
        try {
            const response = await this.fetch(`${this.url}/swapi/people`);

            //TODO Need ot handle failed response

            return await response.json();
        } catch (err) {
            console.error('Command Error', err);
            //TODO Show error page
        }
    }

    public static async Search(query: string) {
        try {
            const response = await this.fetch(`${this.url}/chuck/search?query=${query}`);

            //TODO Need ot handle failed response

            return await response.json();
        } catch (err) {
            console.error('Command Error', err);
            //TODO Show error page
        }
    }
}