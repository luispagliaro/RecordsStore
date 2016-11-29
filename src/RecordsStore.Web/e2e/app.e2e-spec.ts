import { RecordsStorePage } from './app.po';

describe('records-store App', function() {
  let page: RecordsStorePage;

  beforeEach(() => {
    page = new RecordsStorePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
