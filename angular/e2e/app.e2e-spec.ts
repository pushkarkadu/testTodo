import { MyApplicationTemplatePage } from './app.po';

describe('MyApplication App', function() {
  let page: MyApplicationTemplatePage;

  beforeEach(() => {
    page = new MyApplicationTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
