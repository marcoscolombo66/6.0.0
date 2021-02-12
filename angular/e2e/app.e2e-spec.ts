import { Futbol3TemplatePage } from './app.po';

describe('Futbol3 App', function() {
  let page: Futbol3TemplatePage;

  beforeEach(() => {
    page = new Futbol3TemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
